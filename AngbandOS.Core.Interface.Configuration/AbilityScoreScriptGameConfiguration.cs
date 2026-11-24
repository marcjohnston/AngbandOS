using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class AbilityScoreScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Learned Details",
        Description = "Details describing what is learned when this ability score script is used.")]
    public virtual string LearnedDetails { get; set; } = "";

    [ConfigurationProperty("bool",
        Title = "Uses Item",
        Description = "Determines whether using this ability score script requires an item.")]
    public virtual bool UsesItem { get; set; } = true;

    [ConfigurationProperty("AbilitiesEnum",
        Title = "Ability",
        Description = "The binding key that identifies the ability associated with this script.")]
    public virtual AbilitiesEnum AbilityEnumValue { get; set; }

    [ConfigurationProperty("bool",
        Title = "True To Increase False To Decrease",
        Description = "Determines whether the script increases the ability score when true or decreases it when false.")]
    public virtual bool TrueToIncreaseFalseToDecrease { get; set; }
}