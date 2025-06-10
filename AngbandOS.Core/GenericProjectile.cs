// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class GenericProjectile : Projectile
{
    public GenericProjectile(Game game, ProjectileGameConfiguration projectileGameConfiguration) : base(game)
    {
        Key = projectileGameConfiguration.Key ?? projectileGameConfiguration.GetType().Name;
        FloorEffectBindingKey = projectileGameConfiguration.FloorEffectBindingKey;
        ItemEffectBindingKey = projectileGameConfiguration.ItemEffectBindingKey;
        PlayerEffectBindingKey = projectileGameConfiguration.PlayerEffectBindingKey;
        MonsterEffectBindingKey = projectileGameConfiguration.MonsterEffectBindingKey;
        BoltProjectileGraphicBindingKey = projectileGameConfiguration.BoltProjectileGraphicBindingKey;
        EffectAnimationBindingKey = projectileGameConfiguration.EffectAnimationBindingKey;
        ImpactProjectileGraphicBindingKey = projectileGameConfiguration.ImpactProjectileGraphicBindingKey;
    }

    public override string Key { get; }

    protected override string FloorEffectBindingKey { get; }
    protected override string ItemEffectBindingKey { get; }
    protected override string PlayerEffectBindingKey { get; }
    protected override string MonsterEffectBindingKey { get; }
    protected override string? BoltProjectileGraphicBindingKey { get; }
    protected override string? EffectAnimationBindingKey { get; }
    protected override string? ImpactProjectileGraphicBindingKey { get; }
}