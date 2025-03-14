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

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(GreenBulletProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(GreenSplatProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(GreenCloudAnimation));

    protected override string AffectMonsterScriptBindingKey => nameof(PoisonGasMonsterEffect);

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = Game.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            Game.MsgPrint("You are hit by poison!");
        }
        if (Game.HasPoisonResistance)
        {
            dam = (dam + 2) / 3;
        }
        if (Game.PoisonResistanceTimer.Value != 0)
        {
            dam = (dam + 2) / 3;
        }
        if (!(Game.PoisonResistanceTimer.Value != 0 || Game.HasPoisonResistance) &&
            Game.DieRoll(Game.HurtChance) == 1)
        {
            Game.TryDecreasingAbilityScore(AbilityEnum.Constitution);
        }
        Game.TakeHit(dam, killer);
        if (!(Game.HasPoisonResistance || Game.PoisonResistanceTimer.Value != 0))
        {
            if (Game.DieRoll(10) <= Game.SingletonRepository.Get<God>(nameof(HagargRyonisGod)).AdjustedFavour)
            {
                Game.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else
            {
                Game.PoisonTimer.AddTimer(Game.RandomLessThan(dam) + 10);
            }
        }
        return true;
    }
}