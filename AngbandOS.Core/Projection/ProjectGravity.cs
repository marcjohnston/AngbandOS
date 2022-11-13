// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;

using AngbandOS.Core.Interface;
using AngbandOS.Core;
using AngbandOS.Core.MonsterRaces;

namespace AngbandOS.Projection
{
    internal class ProjectGravity : Projectile
    {
        public ProjectGravity(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "TurquoiseBolt";

        protected override string ImpactGraphic => "TurquoiseSplat";

        protected override bool AffectItem(int who, int y, int x)
        {
            return false;
        }

        protected override bool AffectMonster(int who, int r, int y, int x, int dam)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            Monster mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            int doStun = 0;
            string note = null;
            string noteDies = " dies.";
            if (cPtr.MonsterIndex == 0)
            {
                return false;
            }
            if (who != 0 && cPtr.MonsterIndex == who)
            {
                return false;
            }
            dam = (dam + r) / (r + 1);
            string mName = mPtr.MonsterDesc(0);
            if ((rPtr.Flags3 & MonsterFlag3.Demon) != 0 || (rPtr.Flags3 & MonsterFlag3.Undead) != 0 ||
                (rPtr.Flags3 & MonsterFlag3.Cthuloid) != 0 || (rPtr.Flags2 & MonsterFlag2.Stupid) != 0 ||
                (rPtr.Flags3 & MonsterFlag3.Nonliving) != 0 || "Evg".Contains(rPtr.Character.ToString()))
            {
                noteDies = " is destroyed.";
            }
            if (who == 0 && (mPtr.Mind & Constants.SmFriendly) != 0)
            {
                if (who == 0)
                {
                    SaveGame.MsgPrint($"{mName} gets angry!");
                    mPtr.Mind &= ~Constants.SmFriendly;
                }
            }
            bool resistTele = false;
            if (seen)
            {
                obvious = true;
            }
            if ((rPtr.Flags3 & MonsterFlag3.ResistTeleport) != 0)
            {
                if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
                {
                    if (seen)
                    {
                        rPtr.Knowledge.RFlags3 |= MonsterFlag3.ResistTeleport;
                    }
                    note = " is unaffected!";
                    resistTele = true;
                }
                else if (rPtr.Level > Program.Rng.DieRoll(100))
                {
                    if (seen)
                    {
                        rPtr.Knowledge.RFlags3 |= MonsterFlag3.ResistTeleport;
                    }
                    note = " resists!";
                    resistTele = true;
                }
            }
            int doDist = resistTele ? 0 : 10;
            if ((rPtr.Flags4 & MonsterFlag4.BreatheGravity) != 0)
            {
                note = " resists.";
                dam *= 3;
                dam /= Program.Rng.DieRoll(6) + 6;
                doDist = 0;
            }
            else
            {
                if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0 ||
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
                if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0 ||
                    rPtr.Level > Program.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
                {
                    doStun = 0;
                    note = " is unaffected!";
                    obvious = false;
                }
            }
            if ((rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
            {
                if (who != 0 && dam > mPtr.Health)
                {
                    dam = mPtr.Health;
                }
            }
            if ((rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
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
                Monster targetMonster = SaveGame.Level.Monsters[cPtr.MonsterIndex];
                targetMonster.TeleportAway(SaveGame, doDist);
                y = mPtr.MapY;
                x = mPtr.MapX;
                cPtr = SaveGame.Level.Grid[y][x];
            }
            else if (doStun != 0 && (rPtr.Flags4 & MonsterFlag4.BreatheSound) == 0 &&
                     (rPtr.Flags4 & MonsterFlag4.BreatheForce) == 0)
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
                    SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                }
                mPtr.SleepLevel = 0;
                mPtr.Health -= dam;
                if (mPtr.Health < 0)
                {
                    bool sad = (mPtr.Mind & Constants.SmFriendly) != 0 && !mPtr.IsVisible;
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
            SaveGame.Level.Monsters.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
            SaveGame.Level.RedrawSingleLocation(y, x);
            ProjectMn++;
            ProjectMx = x;
            ProjectMy = y;
            return obvious;
        }

        protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
        {
            bool blind = SaveGame.Player.TimedBlindness != 0;
            bool fuzzy = false;
            if (x != SaveGame.Player.MapX || y != SaveGame.Player.MapY)
            {
                return false;
            }
            if (who == 0)
            {
                return false;
            }
            if (SaveGame.Player.HasReflection && aRad == 0 && Program.Rng.DieRoll(10) != 1)
            {
                int tY;
                int tX;
                int maxAttempts = 10;
                SaveGame.MsgPrint(blind ? "Something bounces!" : "The attack bounces!");
                do
                {
                    tY = SaveGame.Level.Monsters[who].MapY - 1 + Program.Rng.DieRoll(3);
                    tX = SaveGame.Level.Monsters[who].MapX - 1 + Program.Rng.DieRoll(3);
                    maxAttempts--;
                } while (maxAttempts > 0 && SaveGame.Level.InBounds2(tY, tX) && !SaveGame.Level.PlayerHasLosBold(tY, tX));
                if (maxAttempts < 1)
                {
                    tY = SaveGame.Level.Monsters[who].MapY;
                    tX = SaveGame.Level.Monsters[who].MapX;
                }
                Fire(0, 0, tY, tX, dam, ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill);
                SaveGame.Disturb(true);
                return true;
            }
            if (dam > 1600)
            {
                dam = 1600;
            }
            dam = (dam + r) / (r + 1);
            if (blind)
            {
                fuzzy = true;
            }
            Monster mPtr = SaveGame.Level.Monsters[who];
            string killer = mPtr.MonsterDesc(0x88);
            if (fuzzy)
            {
                SaveGame.MsgPrint("You are hit by something heavy!");
            }
            SaveGame.MsgPrint("Gravity warps around you.");
            SaveGame.TeleportPlayer(5);
            if (!SaveGame.Player.HasFeatherFall)
            {
                SaveGame.Player.SetTimedSlow(SaveGame.Player.TimedSlow + Program.Rng.RandomLessThan(4) + 4);
            }
            if (!(SaveGame.Player.HasSoundResistance || SaveGame.Player.HasFeatherFall))
            {
                int kk = Program.Rng.DieRoll(dam > 90 ? 35 : (dam / 3) + 5);
                SaveGame.Player.SetTimedStun(SaveGame.Player.TimedStun + kk);
            }
            if (SaveGame.Player.HasFeatherFall)
            {
                dam = dam * 2 / 3;
            }
            if (!SaveGame.Player.HasFeatherFall || Program.Rng.DieRoll(13) == 1)
            {
                SaveGame.Player.Inventory.InvenDamage(SaveGame.SetColdDestroy, 2);
            }
            SaveGame.Player.TakeHit(dam, killer);
            SaveGame.Disturb(true);
            return true;
        }
    }
}