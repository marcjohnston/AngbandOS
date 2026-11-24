using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class SummonScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("bool",
        Title = "Pet",
        Description = "Returns true, to summon a friendly monster (a.k.a pet); false, otherwise. Returns false, by default.")]
    public virtual bool Pet { get; set; } = false;

    [ConfigurationProperty("string",
        Title = "Group Boolean Expression",
        Description = "Returns a boolean expression that is computed to determine whether the summoning of the monster will produce a group of like-monsters. Returns true, by default.")]
    public virtual string GroupBooleanExpression { get; set; } = "true";

    [ConfigurationProperty("string",
        Title = "Monster Filter Binding Key",
        Description = "The binding key of the monster filter used to select monsters for summoning.")]
    public virtual string MonsterFilterBindingKey { get; set; }

    [ConfigurationProperty("string",
        Title = "Level Roll Expression",
        Description = "The expression used to determine the level of summoned monsters.")]
    public virtual string LevelRollExpression { get; set; }

    [ConfigurationProperty("string[]?",
        Title = "Pre-Messages",
        Description = "The messages displayed before summoning is attempted.")]
    public virtual string[]? PreMessages { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Success Messages",
        Description = "The messages displayed when summoning succeeds.")]
    public virtual string[]? SuccessMessages { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Failure Messages",
        Description = "The messages displayed when summoning fails.")]
    public virtual string[]? FailureMessages { get; set; } = null;

    [ConfigurationProperty("string",
        Title = "Learned Details",
        Description = "The details displayed for the learned summoning script.")]
    public virtual string LearnedDetails { get; set; } = "";

    [ConfigurationProperty("bool",
        Title = "Used",
        Description = "Determines whether the summoning script is used.")]
    public virtual bool Used { get; set; } = true;
}

