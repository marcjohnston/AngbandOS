using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class SummonScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationPropertyAttribute(
        Title = "Pet",
        Summary = "Returns true, to summon a friendly monster (a.k.a pet); false, otherwise. Returns false, by default.",
        DataType = "bool")]
    public virtual bool Pet { get; set; } = false;

    [ConfigurationPropertyAttribute(
        Title = "Group Boolean Expression",
        Summary = "Returns a boolean expression that is computed to determine whether the summoning of the monster will produce a group of like-monsters. Returns true, by default.",
        DataType = "string")]
    public virtual string GroupBooleanExpression { get; set; } = "true";

    [ConfigurationPropertyAttribute(
        Title = "Monster Filter Binding Key",
        Summary = "The binding key of the monster filter used to select monsters for summoning.",
        DataType = "string")]
    public virtual string MonsterFilterBindingKey { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Level Roll Expression",
        Summary = "The expression used to determine the level of summoned monsters.",
        DataType = "string")]
    public virtual string LevelRollExpression { get; set; }

    [ConfigurationPropertyAttribute(
        Title = "Pre-Messages",
        Summary = "The messages displayed before summoning is attempted.",
        DataType = "string[]?")]
    public virtual string[]? PreMessages { get; set; } = null;

    [ConfigurationPropertyAttribute(
        Title = "Success Messages",
        Summary = "The messages displayed when summoning succeeds.",
        DataType = "string[]?")]
    public virtual string[]? SuccessMessages { get; set; } = null;

    [ConfigurationPropertyAttribute(
        Title = "Failure Messages",
        Summary = "The messages displayed when summoning fails.",
        DataType = "string[]?")]
    public virtual string[]? FailureMessages { get; set; } = null;

    [ConfigurationPropertyAttribute(
        Title = "Learned Details",
        Summary = "The details displayed for the learned summoning script.",
        DataType = "string")]
    public virtual string LearnedDetails { get; set; } = "";

    [ConfigurationPropertyAttribute(
        Title = "Used",
        Summary = "Determines whether the summoning script is used.",
        DataType = "bool")]
    public virtual bool Used { get; set; } = true;
}

