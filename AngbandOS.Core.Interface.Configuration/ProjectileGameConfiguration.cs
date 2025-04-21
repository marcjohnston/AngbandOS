namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ProjectileGameConfiguration
{
    public virtual string Key { get; set; }

    public virtual string FloorEffectBindingKey { get; set; }
    public virtual string ItemEffectBindingKey { get; set; }
    public virtual string PlayerEffectBindingKey { get; set; }
    public virtual string MonsterEffectBindingKey { get; set; }
    public virtual string? BoltProjectileGraphicBindingKey { get; set; }
    public virtual string? EffectAnimationBindingKey { get; set; }
    public virtual string? ImpactProjectileGraphicBindingKey { get; set; }
}