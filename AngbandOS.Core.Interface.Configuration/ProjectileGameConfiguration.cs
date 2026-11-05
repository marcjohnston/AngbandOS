using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ProjectileGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(
        Title = "Floor Effect Binding Key",
        Summary = "Specifies the binding key for the floor effect script used by the projectile.",
        DataType = "string")]
    public virtual string FloorEffectBindingKey { get; set; } = nameof(GridTileScriptsEnum.UnnoticedGridTileScript);

    [ConfigurationProperty(
        Title = "Item Effect Binding Key",
        Summary = "Specifies the binding key for the item effect script used by the projectile.",
        DataType = "string")]
    public virtual string ItemEffectBindingKey { get; set; } = nameof(ItemEffectScriptsEnum.UnnoticedItemEffect);

    [ConfigurationProperty(
        Title = "Player Effect Binding Key",
        Summary = "Specifies the binding key for the player effect script used by the projectile.",
        DataType = "string")]
    public virtual string PlayerEffectBindingKey { get; set; } = nameof(PlayerEffectScriptsEnum.NoticedPlayerEffect);

    [ConfigurationProperty(
        Title = "Monster Effect Binding Key",
        Summary = "Specifies the binding key for the monster effect script used by the projectile.",
        DataType = "string")]
    public virtual string MonsterEffectBindingKey { get; set; } = nameof(MonsterEffectScriptsEnum.UnnoticedMonsterEffect);

    [ConfigurationProperty(
        Title = "Bolt Projectile Graphic Binding Key",
        Summary = "Specifies the optional binding key for the projectile graphic used by a bolt.",
        DataType = "string?")]
    public virtual string? BoltProjectileGraphicBindingKey { get; set; }

    [ConfigurationProperty(
        Title = "Effect Animation Binding Key",
        Summary = "Specifies the optional binding key for the animation used by the projectile effect.",
        DataType = "string?")]
    public virtual string? EffectAnimationBindingKey { get; set; }

    [ConfigurationProperty(
        Title = "Impact Projectile Graphic Binding Key",
        Summary = "Specifies the optional binding key for the projectile graphic used on impact.",
        DataType = "string?")]
    public virtual string? ImpactProjectileGraphicBindingKey { get; set; }
}
