// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class ElectricityProjectile : Projectile
{
    private ElectricityProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BrightYellowBoltProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BrightYellowCloudAnimation));

    protected override string ItemEffectBindingKey => nameof(ElectricityItemEffect);

    protected override string MonsterEffectBindingKey => nameof(ElectricityMonsterEffect);

    protected override string PlayerEffectBindingKey => nameof(ElectricityPlayerEffect);
}