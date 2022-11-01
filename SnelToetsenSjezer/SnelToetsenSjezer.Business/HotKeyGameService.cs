using System.Collections.Immutable;
using System.Diagnostics;
using SnelToetsenSjezer.Domain.Models;
using SnelToetsenSjezer.Domain.Types;
using GameStateCallbackData = System.Collections.Generic.Dictionary<string, string>;
using Timer = System.Windows.Forms.Timer;

namespace SnelToetsenSjezer.Business;

public class HotKeyGameService
{
    private readonly SortedSet<ModifierKey> _activeModifiers = new();

    private readonly IReadOnlyDictionary<string, ModifierKey> _modifiers
        = new Dictionary<string, ModifierKey>()
        {
            ["Menu"] = ModifierKey.Alt,
            ["ControlKey"] = ModifierKey.Ctrl,
            ["ShiftKey"] = ModifierKey.Shift,
        };

    private List<HotKey> _gameHotKeys = new() { };
    private static PressedKeysDict _currentlyPressedKeys = new();

    private Action<string, GameStateCallbackData> gameStateUpdatedCallback = null;
    private Action<int, bool> gameTimerCallback = null;

    private static Timer? _gameTimer = null;
    private static int _gameSeconds = 0;

    private static bool _isPaused = false;
    private static readonly int _pauseDurationDefault = 2;
    private static int _pauseDuration = 0;

    private HotKeySolution _userInputSteps = new();

    private int _currHotKey = 0;
    private bool _dealingWithFails = false;

    public void SetHotKeys(List<HotKey> hotKeys)
    {
        hotKeys.ForEach(hotKey =>
        {
            hotKey.ResetForNewGame();
        });
        _gameHotKeys = hotKeys;
    }

    public void SetGameStateUpdatedCallback(Action<string, GameStateCallbackData> callback)
    {
        gameStateUpdatedCallback = callback;
    }

    public void SetGameTimerCallback(Action<int, bool> callback)
    {
        gameTimerCallback = callback;
    }

    public void StartGame()
    {
        Debug.WriteLine("Starting game!");
        if (_gameTimer != null) _gameTimer.Dispose();
        _gameSeconds = 0;
        _gameTimer = new Timer();
        _gameTimer.Interval = 1000;
        _gameTimer.Tick += new EventHandler(GameTimer_Tick);
        _gameTimer.Start();

        GameStateCallbackData stateData = new();
        stateData.Add("index", "1");
        stateData.Add("count", _gameHotKeys.Count().ToString());
        stateData.Add("category", _gameHotKeys[_currHotKey].Category);
        stateData.Add("description", _gameHotKeys[_currHotKey].Description);

        gameStateUpdatedCallback("playing", stateData);
    }

    public void StopGame(bool forceStop = false)
    {
        Debug.WriteLine("Stopping game!");
        _gameTimer!.Stop();

        _currHotKey = 0;
        _dealingWithFails = false;
        _userInputSteps = new();

        if (!forceStop) gameStateUpdatedCallback("finished", new GameStateCallbackData());
    }

    public void PauseGame()
    {
        Debug.WriteLine("Pausing game!");
        _isPaused = true;
        _pauseDuration = _pauseDurationDefault;
    }

    public void ResumeGame()
    {
        Debug.WriteLine("Resuming game!");
        _isPaused = false;
        NextHotKey();
    }

    public void GameTimer_Tick(object sender, EventArgs e)
    {
        if (!_isPaused)
        {
            _gameSeconds++;
            _gameHotKeys[_currHotKey].Seconds++;
        }
        else
        {
            if (_pauseDuration > 0)
            {
                _pauseDuration--;
            }
            else
            {
                ResumeGame();
            }
        }
        gameTimerCallback(_gameSeconds, _isPaused);
    }

    public void KeyDown(string keyName)
    {
        if (_isPaused) return;
        if (_modifiers.ContainsKey(keyName)) _activeModifiers.Add(_modifiers[keyName]);
        else
        {
            Debug.WriteLine("KeyDown: " + keyName);
            HotKeySolutionStep currentStep = new(keyName, _activeModifiers.ToImmutableSortedSet());
            _userInputSteps.Add(currentStep);
            GameStateCallbackData gameData = new();
            gameData.Add("userinputsteps", _userInputSteps!.ToString());

            gameStateUpdatedCallback("userinputsteps", gameData);
            CheckForProgressOrFail();
        }
    }

    public void KeyUp(string keyName)
    {
        if (_isPaused) return;
        if (_modifiers.ContainsKey(keyName)) _activeModifiers.Remove(_modifiers[keyName]);
        Debug.WriteLine("KeyUp: " + keyName);
    }

    public void CheckForProgressOrFail()
    {
        Debug.WriteLine($"- _userInputSteps: {_userInputSteps}");

        HotKey myHotKey = _gameHotKeys[_currHotKey];
        HotKeySolutions hotKeySolutions = myHotKey.Solutions;

        bool hasAnyMatches = false;
        bool failedString = false;
        int solutionsShorterThenInput = 0;

        hotKeySolutions.Solutions.ToList().ForEach(hkSolution =>
        {
            bool userSequenceMatches = FullyMatchesTo(hkSolution);
            if (userSequenceMatches)
            {
                hasAnyMatches = true;
                if (hkSolution.SolutionSteps.Count == _userInputSteps.SolutionSteps.Count)
                    HotKeyIsCorrect();
            }
        });

        if (!hasAnyMatches)
        {
            Debug.WriteLine("No matches at all, fail!");
            HotKeyIsFailed();
        }
    }

    private bool FullyMatchesTo(HotKeySolution hkSolution)
    {
        List<HotKeySolutionStep> userSteps = _userInputSteps.SolutionSteps;
        List<HotKeySolutionStep> targetSteps = hkSolution.SolutionSteps;
        int numUserSteps = userSteps.Count;
        if (numUserSteps > targetSteps.Count) return false;
        for (int i = 0; i < userSteps.Count; i++)
        {
            if (!userSteps[i].Matches(targetSteps[i])) return false;
        }
        return true;
    }

    public void HotKeyIsCorrect()
    {
        GameStateCallbackData gameData = new();
        gameData.Add("userinputsteps", _userInputSteps.ToString());
        gameStateUpdatedCallback("correct", gameData);
        _gameHotKeys[_currHotKey].Failed = false;
        PauseGame();
    }

    public void HotKeyIsFailed()
    {
        _gameHotKeys[_currHotKey].Failed = true;

        string hotKeySolutionStr = "";
        HotKeySolutions hotKeySolutions = _gameHotKeys[_currHotKey].Solutions;
        string exampleSolution = hotKeySolutions.Solutions.ToList()[0].ToString();

        GameStateCallbackData stateData = new()
        {
            { "solution", hotKeySolutionStr },
            { "userinputsteps", GetUserInputSteps() }
        };
        gameStateUpdatedCallback("failed", stateData);
        PauseGame();
    }

    public void NextHotKey()
    {
        _userInputSteps = new List<List<string>>();
        _currentlyPressedKeys = new PressedKeysDict();
        bool finished = false;

        if (!_dealingWithFails && _currHotKey < _gameHotKeys.Count() - 1)
        {
            _currHotKey++;
        }
        else
        {
            int failsCount = _gameHotKeys.Where(hk => hk.Failed == true).ToList().Count();
            if (failsCount > 0)
            {
                if (!_dealingWithFails) _dealingWithFails = true;

                for (int i = 0; i < _gameHotKeys.Count(); i++)
                {
                    if (_gameHotKeys[i].Failed && (i != _currHotKey))
                    {
                        _currHotKey = i;
                        _gameHotKeys[i].Attempt += 1;
                        break;
                    }
                }
            }
            else
            {
                finished = true;
                StopGame();
            }
        }
        if (!finished)
        {
            GameStateCallbackData stateData = new()
            {
                { "index", (_currHotKey+1).ToString() },
                { "count", _gameHotKeys.Count().ToString() },
                { "attempt", _gameHotKeys[_currHotKey].Attempt.ToString() },
                { "category", _gameHotKeys[_currHotKey].Category },
                { "description", _gameHotKeys[_currHotKey].Description },
                { "userinputsteps", "" }
            };
            gameStateUpdatedCallback("playing", stateData);
        }
    }

    public List<HotKey> GetGameHotKeys()
    {
        return _gameHotKeys;
    }

    public int GetGameDuration()
    {
        return _gameSeconds;
    }
}