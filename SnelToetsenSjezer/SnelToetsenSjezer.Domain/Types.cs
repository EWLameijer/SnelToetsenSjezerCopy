using System.Collections.Immutable;

namespace SnelToetsenSjezer.Domain.Types;

public enum ModifierKey
{ ModifierKeyNotSet, Alt, Ctrl, Shift }

public class PressedKeysDict : Dictionary<string, bool>
{ };

// utility for reading in XML
public class HotKeySolutionStepBuilder
{
    private readonly SortedSet<ModifierKey> _activeModifiers = new();
    private string _mainKey;
    private static readonly IReadOnlyDictionary<string, ModifierKey> _modifiers = HotKeySolutionStep.Modifiers;

    public void Add(string keyCode)
    {
        if (_modifiers.ContainsKey(keyCode)) _activeModifiers.Add(_modifiers[keyCode]);
        else _mainKey = keyCode;
    }

    public HotKeySolutionStep Build()
    {
        if (_mainKey == null) throw new ArgumentException("Main key cannot be undefined!");
        return new HotKeySolutionStep(_mainKey, _activeModifiers.ToImmutableSortedSet());
    }
}

/// <summary>
/// HotKeySolutionStep is a List of SolutionStepPart's.<br/>
/// <br/>
/// 'Steps' are the different bits that come together to form a HotKeySolution, as the name implies they are<br/>
/// the steps of that solution or 'the bits between the commas'
/// </summary>
public class HotKeySolutionStep
{
    public static IReadOnlyDictionary<string, ModifierKey> Modifiers
= new Dictionary<string, ModifierKey>()
{
    ["Menu"] = ModifierKey.Alt,
    ["ControlKey"] = ModifierKey.Ctrl,
    ["ShiftKey"] = ModifierKey.Shift,
};

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