// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
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

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<GreenBulletProjectileGraphic>();

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<GreenSplatProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<GreenCloudAnimation>();

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
        bool blind = SaveGame.Player.TimedBlindness.TurnsRemaining != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = SaveGame.Level.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            SaveGame.MsgPrint("You are hit by poison!");
        }
        if (SaveGame.Player.HasPoisonResistance)
        {
            dam = (dam + 2) / 3;
        }
        if (SaveGame.Player.TimedPoisonResistance.TurnsRemaining != 0)
        {
            dam = (dam + 2) / 3;
        }
        if (!(SaveGame.Player.TimedPoisonResistance.TurnsRemaining != 0 || SaveGame.Player.HasPoisonResistance) &&
            Program.Rng.DieRoll(SaveGame.HurtChance) == 1)
        {
            SaveGame.Player.TryDecreasingAbilityScore(Ability.Constitution);
        }
        SaveGame.Player.TakeHit(dam, killer);
        if (!(SaveGame.Player.HasPoisonResistance || SaveGame.Player.TimedPoisonResistance.TurnsRemaining != 0))
        {
            if (Program.Rng.DieRoll(10) <= SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
            {
                SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else
            {
                SaveGame.Player.TimedPoison.AddTimer(Program.Rng.RandomLessThan(dam) + 10);
            }
        }
        return true;
    }
}