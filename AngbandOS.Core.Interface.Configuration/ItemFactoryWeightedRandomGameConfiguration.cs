
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ItemFactoryWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("(string Name, int Weight)[]",
        Title = "Name and Weight Bindings",
        Description = "The item factory binding keys and their corresponding weights used for weighted random selection.")]
    [ConfigurationTupleItem("Name", Title = "Name")]
    [ConfigurationTupleItem("Weight", Title = "Weight")]
    public virtual (string Name, int Weight)[] NameAndWeightBindings { get; set; }
}