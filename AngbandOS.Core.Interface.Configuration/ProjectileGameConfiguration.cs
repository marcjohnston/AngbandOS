using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ProjectileGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Floor Effect Binding Key",
        Summary = "Specifies the binding key for the floor effect script used by the projectile.")]
    public virtual string FloorEffectBindingKey { get; set; } = nameof(GridTileScriptsEnum.UnnoticedGridTileScript);

    [ConfigurationProperty("string",
        Title = "Item Effect Binding Key",
        Summary = "Specifies the binding key for the item effect script used by the projectile.")]
    public virtual string ItemEffectBindingKey { get; set; } = nameof(ItemEffectScriptsEnum.UnnoticedItemEffect);

    [ConfigurationProperty("string",
        Title = "Player Effect Binding Key",
        Summary = "Specifies the binding key for the player effect script used by the projectile.")]
    public virtual string PlayerEffectBindingKey { get; set; } = nameof(PlayerEffectScriptsEnum.NoticedPlayerEffect);

    [ConfigurationProperty("string",
        Title = "Monster Effect Binding Key",
        Summary = "Specifies the binding key for the monster effect script used by the projectile.")]
    public virtual string MonsterEffectBindingKey { get; set; } = nameof(MonsterEffectScriptsEnum.UnnoticedMonsterEffect);

    [ConfigurationProperty("string?",
        Title = "Bolt Projectile Graphic Binding Key",
        Summary = "Specifies the optional binding key for the projectile graphic used by a bolt.")]
    public virtual string? BoltProjectileGraphicBindingKey { get; set; }

    [ConfigurationProperty("string?",
        Title = "Effect Animation Binding Key",
        Summary = "Specifies the optional binding key for the animation used by the projectile effect.")]
    public virtual string? EffectAnimationBindingKey { get; set; }

    [ConfigurationProperty("string?",
        Title = "Impact Projectile Graphic Binding Key",
        Summary = "Specifies the optional binding key for the projectile graphic used on impact.")]
    public virtual string? ImpactProjectileGraphicBindingKey { get; set; }
}
