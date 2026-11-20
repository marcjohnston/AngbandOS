using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents a singleton for a weighted random of <see cref="ItemEnhancement"/> objects.
/// </summary>
public class ItemEnhancementWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(
        Title = "Name and Weight Bindings",
        Summary = "The names of item enhancements and their corresponding weights used for weighted random selection.",
        DataType = "(string? ItemEnhancementName, int Weight)[]")]
    [ConfigurationTupleItem("ItemEnhancementName", Title = "Item Enhancement Name")]
    [ConfigurationTupleItem("Weight", Title = "Weight")]
    public virtual (string? ItemEnhancementName, int Weight)[] NameAndWeightBindings { get; set; }
}