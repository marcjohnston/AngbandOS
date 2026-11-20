using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class AbilityScoreScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Learned Details",
        Summary = "Details describing what is learned when this ability score script is used.")]
    public virtual string LearnedDetails { get; set; } = "";

    [ConfigurationProperty("bool",
        Title = "Uses Item",
        Summary = "Determines whether using this ability score script requires an item.")]
    public virtual bool UsesItem { get; set; } = true;

    [ConfigurationProperty("AbilitiesEnum",
        Title = "Ability",
        Summary = "The binding key that identifies the ability associated with this script.")]
    public virtual AbilitiesEnum AbilityEnumValue { get; set; }

    [ConfigurationProperty("bool",
        Title = "True To Increase False To Decrease",
        Summary = "Determines whether the script increases the ability score when true or decreases it when false.")]
    public virtual bool TrueToIncreaseFalseToDecrease { get; set; }
}