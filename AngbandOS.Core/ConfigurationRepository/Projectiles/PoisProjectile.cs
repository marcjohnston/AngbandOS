// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class PoisProjectile : Projectile
{
    private PoisProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(GreenBulletProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(GreenSplatProjectileGraphic));

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get(nameof(GreenCloudAnimation));

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.ImmunePoison)
        {
            note = " resists a lot.";
            dam /= 9;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.ImmunePoison = true;
            }
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = SaveGame.TimedBlindness.TurnsRemaining != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = SaveGame.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            SaveGame.MsgPrint("You are hit by poison!");
        }
        if (SaveGame.HasPoisonResistance)
        {
            dam = (dam + 2) / 3;
        }
        if (SaveGame.TimedPoisonResistance.TurnsRemaining != 0)
        {
            dam = (dam + 2) / 3;
        }
        if (!(SaveGame.TimedPoisonResistance.TurnsRemaining != 0 || SaveGame.HasPoisonResistance) &&
            SaveGame.DieRoll(SaveGame.HurtChance) == 1)
        {
            SaveGame.TryDecreasingAbilityScore(Ability.Constitution);
        }
        SaveGame.TakeHit(dam, killer);
        if (!(SaveGame.HasPoisonResistance || SaveGame.TimedPoisonResistance.TurnsRemaining != 0))
        {
            if (SaveGame.DieRoll(10) <= SaveGame.SingletonRepository.Gods.Get(nameof(HagargRyonisGod)).AdjustedFavour)
            {
                SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else
            {
                SaveGame.TimedPoison.AddTimer(SaveGame.RandomLessThan(dam) + 10);
            }
        }
        return true;
    }
}