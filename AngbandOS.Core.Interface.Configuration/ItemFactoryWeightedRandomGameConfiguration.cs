
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ItemFactoryWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Name and Weight Bindings",
        Summary = "The item factory binding keys and their corresponding weights used for weighted random selection.",
        DataType = "(string Name, int Weight)[]")]
    [ConfigurationTupleItem("Name", Title = "Name")]
    [ConfigurationTupleItem("Weight", Title = "Weight")]
    public virtual (string, int)[] NameAndWeightBindings { get; set; }
}