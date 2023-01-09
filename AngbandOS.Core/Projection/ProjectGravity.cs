// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectGravity : Projectile
    {
        public ProjectGravity(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "TurquoiseBolt";

        protected override string ImpactGraphic => "TurquoiseSplat";

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            int doStun = 0;
            string note = null;
            string noteDies = NoteDiesOrIsDestroyed(rPtr);
            string mName = mPtr.Name;
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
                if (rPtr.Unique ||
                    rPtr.Level > Program.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
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
                doStun = Program.Rng.DiceRoll((SaveGame.Player.Level / 10) + 3, dam) + 1;
                if (rPtr.Unique ||
                    rPtr.Level > Program.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
                {
                    doStun = 0;
                    note = " is unaffected!";
                    obvious = false;
                }
            }
            if (rPtr.Guardian)
            {
                if (who != 0 && dam > mPtr.Health)
                {
                    dam = mPtr.Health;
                }
            }
            if (rPtr.Guardian)
            {
                if (who > 0 && dam > mPtr.Health)
                {
                    dam = mPtr.Health;
                }
            }
            if (dam > mPtr.Health)
            {
                note = noteDies;
            }
            else if (doDist != 0)
            {
                if (seen)
                {
                    obvious = true;
                }
                note = " disappears!";
                mPtr.TeleportAway(SaveGame, doDist);
                cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            }
            else if (doStun != 0 && !rPtr.BreatheSound &&
                     !rPtr.BreatheForce)
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
            if (who != 0)
            {
                if (SaveGame.TrackedMonsterIndex == cPtr.MonsterIndex)
                {
                    SaveGame.PrHealthRedrawAction.Set();
                }
                mPtr.SleepLevel = 0;
                mPtr.Health -= dam;
                if (mPtr.Health < 0)
                {
                    bool sad = mPtr.SmFriendly && !mPtr.IsVisible;
                    SaveGame.MonsterDeath(cPtr.MonsterIndex);
                    SaveGame.Level.Monsters.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                    if (string.IsNullOrEmpty(note) == false)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    if (sad)
                    {
                        SaveGame.MsgPrint("You feel sad for a moment.");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(note) == false && seen)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    else if (dam > 0)
                    {
                        SaveGame.Level.Monsters.MessagePain(cPtr.MonsterIndex, dam);
                    }
                }
            }
            else
            {
                if (SaveGame.Level.Monsters.DamageMonster(cPtr.MonsterIndex, dam, out bool fear, noteDies))
                {
                }
                else
                {
                    if (string.IsNullOrEmpty(note) == false && seen)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    else if (dam > 0)
                    {
                        SaveGame.Level.Monsters.MessagePain(cPtr.MonsterIndex, dam);
                    }
                    if (fear && mPtr.IsVisible)
                    {
                        SaveGame.PlaySound(SoundEffect.MonsterFlees);
                        SaveGame.MsgPrint($"{mName} flees in terror!");
                    }
                }
            }
            return obvious;
        }

        protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
        {
            bool blind = SaveGame.Player.TimedBlindness.TimeRemaining != 0;
            if (dam > 1600)
            {
                dam = 1600;
            }
            dam = (dam + r) / (r + 1);
            Monster mPtr = SaveGame.Level.Monsters[who];
            string killer = mPtr.IndefiniteVisibleName;
            if (blind)
            {
                SaveGame.MsgPrint("You are hit by something heavy!");
            }
            SaveGame.MsgPrint("Gravity warps around you.");
            SaveGame.TeleportPlayer(5);
            if (!SaveGame.Player.HasFeatherFall)
            {
                SaveGame.Player.TimedSlow.SetTimer(SaveGame.Player.TimedSlow.TimeRemaining + Program.Rng.RandomLessThan(4) + 4);
            }
            if (!(SaveGame.Player.HasSoundResistance || SaveGame.Player.HasFeatherFall))
            {
                int kk = Program.Rng.DieRoll(dam > 90 ? 35 : (dam / 3) + 5);
                SaveGame.Player.TimedStun.SetTimer(SaveGame.Player.TimedStun.TimeRemaining + kk);
            }
            if (SaveGame.Player.HasFeatherFall)
            {
                dam = dam * 2 / 3;
            }
            if (!SaveGame.Player.HasFeatherFall || Program.Rng.DieRoll(13) == 1)
            {
                SaveGame.Player.InvenDamage(SaveGame.SetColdDestroy, 2);
            }
            SaveGame.Player.TakeHit(dam, killer);
            return true;
        }
    }
}