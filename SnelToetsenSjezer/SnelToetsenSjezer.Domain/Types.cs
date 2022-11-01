using System.Collections.Immutable;

namespace SnelToetsenSjezer.Domain.Types;

public enum ModifierKey
{ ModifierKeyNotSet, Alt, Ctrl, Shift }

public class PressedKeysDict : Dictionary<string, bool>
{ };

public class GameStateCallbackData
{
    private readonly Dictionary<string, string> _dict = new();

    public void Add(string key, string value) => _dict[key] = value;
};

/// <summary>
/// HotKeySolutionStep is a List of SolutionStepPart's.<br/>
/// <br/>
/// 'Steps' are the different bits that come together to form a HotKeySolution, as the name implies they are<br/>
/// the steps of that solution or 'the bits between the commas'
/// </summary>
public class HotKeySolutionStep
{
    private readonly ImmutableSortedSet<ModifierKey> _activeModifiers;
    private readonly string _mainKey;

    public HotKeySolutionStep(string mainKey, ImmutableSortedSet<ModifierKey> activeModifiers)
    {
        _activeModifiers = activeModifiers;
        _mainKey = mainKey;
    }

    public bool Matches(HotKeySolutionStep other) =>
        _mainKey == other._mainKey && _activeModifiers.SetEquals(other._activeModifiers);

    public override string ToString()
    {
        List<string> keysPressed = new();
        if (_activeModifiers.Contains(ModifierKey.Alt)) keysPressed.Add("Alt");
        if (_activeModifiers.Contains(ModifierKey.Ctrl)) keysPressed.Add("Ctrl");
        if (_activeModifiers.Contains(ModifierKey.Shift)) keysPressed.Add("Shift");
        keysPressed.Add(_mainKey);
        return string.Join("+", keysPressed);
    }
}

/// <summary>
/// HotKeySolution is a List of HotKeySolutionStep's.<br/>
/// <br/>
/// 'Solutions' are sets of HotKeySolutionStep's that need to be completed in order to complete the HotKey for the game
/// </summary>
public class HotKeySolution
{
    public List<HotKeySolutionStep> SolutionSteps { get; private set; } = new();

    public void Add(HotKeySolutionStep currentStep)
    {
        SolutionSteps.Add(currentStep);
    }

    public override string ToString() =>
        string.Join(", ", SolutionSteps.Select(ss => ss.ToString()));
}

/// <summary>
/// HotKeySolutions is a List of HotKeySolution's.
/// </summary>
public class HotKeySolutions
{
    public HashSet<HotKeySolution> Solutions { get; set; } = new();

    public int Count => Solutions.Count;
}