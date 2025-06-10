namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents a singleton for a weighted random of <see cref="ItemEnhancement"/> objects.
/// </summary>
[Serializable]
public class ItemEnhancementWeightedRandomGameConfiguration
{
    public virtual string Key { get; set; }

    public virtual (string, int)[] NameAndWeightBindings { get; set; }
}
