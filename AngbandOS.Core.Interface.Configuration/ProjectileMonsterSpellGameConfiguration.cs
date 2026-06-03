namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ProjectileMonsterSpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual bool ItemProjectionFlag { get; set; } = false;
    public virtual bool GridProjectionFlag { get; set; } = false;
    public virtual bool KillProjectionFlag { get; set; } = true;
    public virtual bool StopProjectionFlag { get; set; } = true;

    /// <summary>
    /// Returns the key for the projectile to use.  This property is used to bind the ProjectileProperty during the binding phase.
    /// </summary>
    public virtual string ProjectileKey { get; set; }

    public virtual int? MaxDamage { get; set; } = null;

    /// <summary>
    /// Returns the roll expression that determines the amount of damage the arrow projectile inflicts.  This expression is parse
    /// to generate the DamageDiceRoll.
    /// </summary>
    public virtual string DamageRollExpression { get; set; }
    public virtual bool InverseRadius { get; set; } = false;
    public virtual string RadiusExpressionText { get; set; } = "0";

    public virtual string? PreExecuteOnPlayerScriptBindingKey { get; set; } = null;
    public virtual string? PostExecuteOnPlayerScriptBindingKey { get; set; } = null;
    public virtual string? PreExecuteOnMonsterScriptBindingKey { get; set; } = null;
    public virtual string? PostExecuteOnMonsterScriptBindingKey { get; set; } = null;
}
