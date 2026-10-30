using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents a singleton for a weighted random of <see cref="ItemEnhancement"/> objects.
/// </summary>
public class ItemEnhancementWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Name and Weight Bindings",
        Summary = "The names of item enhancements and their corresponding weights used for weighted random selection.",
        DataType = "(string?, int)[]")]
    [ConfigurationTupleItem("ItemEnhancementName", Title = "Item Enhancement Name")]
    [ConfigurationTupleItem("Weight", Title = "Weight")]
    public virtual (string?, int)[] NameAndWeightBindings { get; set; }
}