using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class SummonWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationTupleItem(
        "Name",
        Title = "Name")]
    [ConfigurationTupleItem(
        "Weight",
        Title = "Weight")]
    [ConfigurationProperty("(string, int)[]",
        Title = "Name and Weight Bindings",
        Summary = "Specifies the summon names and their associated weights used for weighted random selection.")]
    public virtual (string Name, int Weight)[] NameAndWeightBindings { get; set; }

    [ConfigurationProperty("string",
        Title = "Learned Details",
        Summary = "Specifies the information revealed when the summon is learned.")]
    public virtual string LearnedDetails { get; set; } = "";
}