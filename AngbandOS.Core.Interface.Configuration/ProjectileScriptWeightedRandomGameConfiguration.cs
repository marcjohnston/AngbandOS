using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Projectile Script Weighted Random",
    EntityNoun = "projectile script weighted random")]
public class ProjectileScriptWeightedRandomGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationTupleItem(
        "Item1",
        Title = "Item 1")]
    [ConfigurationTupleItem(
        "Item2",
        Title = "Item 2")]
    [ConfigurationMetadata(
        Title = "Name and Weight Bindings",
        Summary = "Specifies the projectile script names and their associated weights used for weighted random selection.",
        DataType = "(string, int)[]")]
    public virtual (string, int)[] NameAndWeightBindings { get; set; }

    [ConfigurationMetadata(
        Title = "Learned Details",
        Summary = "Specifies the details revealed when the projectile script is learned.",
        DataType = "string")]
    public virtual string LearnedDetails { get; set; } = "";

    [ConfigurationMetadata(
        Title = "Learned Details Mode",
        Summary = "Specifies how the learned details are determined.",
        DataType = "LearnedDetailsWeightedRandomEnum")]
    public virtual LearnedDetailsWeightedRandomEnum LearnedDetailsMode { get; set; } = LearnedDetailsWeightedRandomEnum.Default;
}
