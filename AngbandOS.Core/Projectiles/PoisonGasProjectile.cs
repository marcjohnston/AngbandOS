// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class PoisonGasProjectile : Projectile
{
    private PoisonGasProjectile(Game game) : base(game) { }

    protected override string? BoltProjectileGraphicBindingKey => nameof(GreenBulletProjectileGraphic);

    protected override string? ImpactProjectileGraphicBindingKey => nameof(GreenSplatProjectileGraphic);

    protected override string? EffectAnimationBindingKey => nameof(GreenCloudAnimation);

    protected override string MonsterEffectBindingKey => nameof(PoisonGasMonsterEffect);

    protected override string PlayerEffectBindingKey => nameof(PoisonGasPlayerEffect);
}