using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class AbilityScoreScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(
        Title = "Learned Details",
        Summary = "Details describing what is learned when this ability score script is used.",
        DataType = "string")]
    public virtual string LearnedDetails { get; set; } = "";

    [ConfigurationProperty(
        Title = "Uses Item",
        Summary = "Determines whether using this ability score script requires an item.",
        DataType = "bool")]
    public virtual bool UsesItem { get; set; } = true;

    [ConfigurationProperty(
        Title = "Ability",
        Summary = "The binding key that identifies the ability associated with this script.",
        DataType = "AbilitiesEnum")]
    public virtual AbilitiesEnum AbilityEnumValue { get; set; }

    [ConfigurationProperty(
        Title = "True To Increase False To Decrease",
        Summary = "Determines whether the script increases the ability score when true or decreases it when false.",
        DataType = "bool")]
    public virtual bool TrueToIncreaseFalseToDecrease { get; set; }
}