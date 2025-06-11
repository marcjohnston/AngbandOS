namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class ProjectileGameConfiguration
{
    public virtual string? Key { get; set; } = null;

    public virtual string FloorEffectBindingKey { get; set; } = nameof(FloorEffectScriptsEnum.UnnoticedFloorEffect);
    public virtual string ItemEffectBindingKey { get; set; } = nameof(ItemEffectScriptsEnum.UnnoticedItemEffect);
    public virtual string PlayerEffectBindingKey { get; set; } = nameof(PlayerEffectScriptsEnum.NoticedPlayerEffect);
    public virtual string MonsterEffectBindingKey { get; set; } = nameof(MonsterEffectScriptsEnum.UnnoticedMonsterEffect);
    public virtual string? BoltProjectileGraphicBindingKey { get; set; }
    public virtual string? EffectAnimationBindingKey { get; set; }
    public virtual string? ImpactProjectileGraphicBindingKey { get; set; }
}
