namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ProjectileGameConfiguration
{
    public virtual string Key { get; set; }

    public virtual string FloorEffectBindingKey { get; set; } = nameof(FloorEffectScripts.UnnoticedFloorEffect);
    public virtual string ItemEffectBindingKey { get; set; } = nameof(ItemEffectScripts.UnnoticedItemEffect);
    public virtual string PlayerEffectBindingKey { get; set; } = nameof(PlayerEffectScripts.NoticedPlayerEffect);
    public virtual string MonsterEffectBindingKey { get; set; } = nameof(MonsterEffectScripts.UnnoticedMonsterEffect);
    public virtual string? BoltProjectileGraphicBindingKey { get; set; }
    public virtual string? EffectAnimationBindingKey { get; set; }
    public virtual string? ImpactProjectileGraphicBindingKey { get; set; }
}
