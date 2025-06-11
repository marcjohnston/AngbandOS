namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class SummonScriptGameConfiguration
{
    public virtual string? Key { get; set; } = null;

    /// <summary>
    /// Returns true, to summon a friendly monster (a.k.a pet); false, otherwise.  Returns false, by default.
    /// </summary>
    public virtual bool Pet { get; set; } = false;

    /// <summary>
    /// Returns a boolean expression that is computed to determine whether the summoning of the monster will produce a group of like-monsters.  Returns true, by default.
    /// </summary>
    public virtual string GroupBooleanExpression { get; set; } = "true";

    public virtual string MonsterFilterBindingKey { get; set; }
    public virtual string LevelRollExpression { get; set; }
    public virtual string[]? PreMessages { get; set; } = null;
    public virtual string[]? SuccessMessages { get; set; } = null;
    public virtual string[]? FailureMessages { get; set; } = null;
}

