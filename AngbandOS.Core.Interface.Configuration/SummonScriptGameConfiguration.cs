using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class SummonScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("bool",
        Title = "Pet",
        Summary = "Returns true, to summon a friendly monster (a.k.a pet); false, otherwise. Returns false, by default.")]
    public virtual bool Pet { get; set; } = false;

    [ConfigurationProperty("string",
        Title = "Group Boolean Expression",
        Summary = "Returns a boolean expression that is computed to determine whether the summoning of the monster will produce a group of like-monsters. Returns true, by default.")]
    public virtual string GroupBooleanExpression { get; set; } = "true";

    [ConfigurationProperty("string",
        Title = "Monster Filter Binding Key",
        Summary = "The binding key of the monster filter used to select monsters for summoning.")]
    public virtual string MonsterFilterBindingKey { get; set; }

    [ConfigurationProperty("string",
        Title = "Level Roll Expression",
        Summary = "The expression used to determine the level of summoned monsters.")]
    public virtual string LevelRollExpression { get; set; }

    [ConfigurationProperty("string[]?",
        Title = "Pre-Messages",
        Summary = "The messages displayed before summoning is attempted.")]
    public virtual string[]? PreMessages { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Success Messages",
        Summary = "The messages displayed when summoning succeeds.")]
    public virtual string[]? SuccessMessages { get; set; } = null;

    [ConfigurationProperty("string[]?",
        Title = "Failure Messages",
        Summary = "The messages displayed when summoning fails.")]
    public virtual string[]? FailureMessages { get; set; } = null;

    [ConfigurationProperty("string",
        Title = "Learned Details",
        Summary = "The details displayed for the learned summoning script.")]
    public virtual string LearnedDetails { get; set; } = "";

    [ConfigurationProperty("bool",
        Title = "Used",
        Summary = "Determines whether the summoning script is used.")]
    public virtual bool Used { get; set; } = true;
}

