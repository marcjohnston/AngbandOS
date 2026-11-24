using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ProjectileScriptWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationTupleItem(
        "Name",
        Title = "Name")]
    [ConfigurationTupleItem(
        "Weight",
        Title = "Weight")]
    [ConfigurationProperty("(string Name, int Weight)[]",
        Title = "Name and Weight Bindings",
        Description = "Specifies the projectile script names and their associated weights used for weighted random selection.")]
    public virtual (string Name, int Weight)[] NameAndWeightBindings { get; set; }

    [ConfigurationProperty("string",
        Title = "Learned Details",
        Description = "Specifies the details revealed when the projectile script is learned.")]
    public virtual string LearnedDetails { get; set; } = "";

    [ConfigurationProperty("LearnedDetailsWeightedRandomEnum",
        Title = "Learned Details Mode",
        Description = "Specifies how the learned details are determined.")]
    public virtual LearnedDetailsWeightedRandomEnum LearnedDetailsMode { get; set; } = LearnedDetailsWeightedRandomEnum.Default;
}
