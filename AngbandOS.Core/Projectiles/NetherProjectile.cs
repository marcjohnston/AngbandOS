// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class NetherProjectile : Projectile
{
    private NetherProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<BlackBoltProjectileGraphic>();

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<BlackSplatProjectileGraphic>();

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
        if (rPtr.Undead)
        {
            note = " is immune.";
            dam = 0;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Undead = true;
            }
        }
        else if (rPtr.ResistNether)
        {
            note = " resists.";
            dam *= 3;
            dam /= Program.Rng.DieRoll(6) + 6;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.ResistNether = true;
            }
        }
        else if (rPtr.Evil)
        {
            dam /= 2;
            note = " resists somewhat.";
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Evil = true;
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
            SaveGame.MsgPrint("You are hit by nether forces!");
        }
        if (SaveGame.Player.HasNetherResistance)
        {
            if (SaveGame.Player.Race.NegatesNetherResistance)
            {
                dam *= 6;
            }
            dam /= Program.Rng.DieRoll(6) + 6;
        }
        else
        {
            if (SaveGame.Player.HasHoldLife && Program.Rng.RandomLessThan(100) < 75)
            {
                SaveGame.MsgPrint("You keep hold of your life force!");
            }
            else if (Program.Rng.DieRoll(10) <= SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
            {
                SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (SaveGame.Player.HasHoldLife)
            {
                SaveGame.MsgPrint("You feel your life slipping away!");
                SaveGame.Player.LoseExperience(200 + (SaveGame.Player.ExperiencePoints / 1000 * Constants.MonDrainLife));
            }
            else
            {
                SaveGame.MsgPrint("You feel your life draining away!");
                SaveGame.Player.LoseExperience(200 + (SaveGame.Player.ExperiencePoints / 100 * Constants.MonDrainLife));
            }
        }
        if (SaveGame.Player.Race.ProjectingNetherRestoresHealth)
        {
            SaveGame.MsgPrint("You feel invigorated!");
            SaveGame.Player.RestoreHealth(dam / 4);
        }
        else
        {
            SaveGame.Player.TakeHit(dam, killer);
        }
        return true;
    }
}