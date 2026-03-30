namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents a singleton for a weighted random of <see cref="ItemEnhancement"/> objects.
/// </summary>
[Serializable]
public class ItemEnhancementWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual (string?, int)[] NameAndWeightBindings { get; set; }
}
