// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class GravityProjectile : Projectile
{
    private GravityProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<TurquoiseBoltProjectileGraphic>();

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<TurquoiseSplatProjectileGraphic>();

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        int doStun = 0;
        string? note = null;
        bool resistTele = false;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.ResistTeleport)
        {
            if (rPtr.Unique)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ResistTeleport = true;
                }
                note = " is unaffected!";
                resistTele = true;
            }
            else if (rPtr.Level > Program.Rng.DieRoll(100))
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ResistTeleport = true;
                }
                note = " resists!";
                resistTele = true;
            }
        }
        int doDist = resistTele ? 0 : 10;
        if (rPtr.BreatheGravity)
        {
            note = " resists.";
            dam *= 3;
            dam /= Program.Rng.DieRoll(6) + 6;
            doDist = 0;
        }
        else
        {
            if (rPtr.Unique || rPtr.Level > Program.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
            {
                obvious = false;
            }
            else
            {
                if (mPtr.Speed > 60)
                {
                    mPtr.Speed -= 10;
                }
                note = " starts moving slower.";
            }
            doStun = Program.Rng.DiceRoll((SaveGame.ExperienceLevel / 10) + 3, dam) + 1;
            if (rPtr.Unique || rPtr.Level > Program.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
            {
                doStun = 0;
                note = " is unaffected!";
                obvious = false;
            }
        }
        if (doDist != 0)
        {
            if (seen)
            {
                obvious = true;
            }
            note = " disappears!";
            mPtr.TeleportAway(SaveGame, doDist);
        }
        else if (doStun != 0 && !rPtr.BreatheSound && !rPtr.BreatheForce)
        {
            if (seen)
            {
                obvious = true;
            }
            int tmp;
            if (mPtr.StunLevel != 0)
            {
                note = " is more dazed.";
                tmp = mPtr.StunLevel + (doStun / 2);
            }
            else
            {
                note = " is dazed.";
                tmp = doStun;
            }
            mPtr.StunLevel = tmp < 200 ? tmp : 200;
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
            SaveGame.MsgPrint("You are hit by something heavy!");
        }
        SaveGame.MsgPrint("Gravity warps around you.");
        SaveGame.TeleportPlayer(5);
        if (!SaveGame.HasFeatherFall)
        {
            SaveGame.TimedSlow.AddTimer(Program.Rng.RandomLessThan(4) + 4);
        }
        if (!(SaveGame.HasSoundResistance || SaveGame.HasFeatherFall))
        {
            int kk = Program.Rng.DieRoll(dam > 90 ? 35 : (dam / 3) + 5);
            SaveGame.TimedStun.AddTimer(kk);
        }
        if (SaveGame.HasFeatherFall)
        {
            dam = dam * 2 / 3;
        }
        if (!SaveGame.HasFeatherFall || Program.Rng.DieRoll(13) == 1)
        {
            SaveGame.InvenDamage(SaveGame.SetColdDestroy, 2);
        }
        SaveGame.TakeHit(dam, killer);
        return true;
    }
}