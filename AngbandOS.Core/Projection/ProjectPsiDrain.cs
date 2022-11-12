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
    internal class ProjectPsiDrain : Projectile
    {
        public ProjectPsiDrain(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BeigeBolt";

        protected override string EffectAnimation => "BeigeContract";

        protected override bool AffectFloor(int y, int x)
        {
            return false;
        }

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
            string note = null;
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
            if (who == 0 && (mPtr.Mind & Constants.SmFriendly) != 0)
            {
                bool getAngry = (rPtr.Flags2 & MonsterFlag2.EmptyMind) == 0;
                if (getAngry && who == 0)
                {
                    SaveGame.MsgPrint($"{mName} gets angry!");
                    mPtr.Mind &= ~Constants.SmFriendly;
                }
            }
            if (seen)
            {
                obvious = true;
            }
            if ((rPtr.Flags2 & MonsterFlag2.EmptyMind) != 0)
            {
                dam = 0;
                note = " is immune!";
            }
            else if ((rPtr.Flags2 & MonsterFlag2.Stupid) != 0 || (rPtr.Flags2 & MonsterFlag2.WeirdMind) != 0 ||
                     (rPtr.Flags3 & MonsterFlag3.Animal) != 0 || rPtr.Level > Program.Rng.DieRoll(3 * dam))
            {
                dam /= 3;
                note = " resists.";
                if (((rPtr.Flags3 & MonsterFlag3.Undead) != 0 || (rPtr.Flags3 & MonsterFlag3.Demon) != 0) &&
                    rPtr.Level > SaveGame.Player.Level / 2 && Program.Rng.DieRoll(2) == 1)
                {
                    note = null;
                    string s = seen ? "'s" : "s";
                    SaveGame.MsgPrint($"{mName}{s} corrupted mind backlashes your attack!");
                    if (Program.Rng.RandomLessThan(100) < SaveGame.Player.SkillSavingThrow)
                    {
                        SaveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        string killer = mPtr.MonsterDesc(0x88);
                        SaveGame.MsgPrint("Your psychic energy is drained!");
                        SaveGame.Player.Mana = Math.Max(0, SaveGame.Player.Mana - (Program.Rng.DiceRoll(5, dam) / 2));
                        SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMana);
                        SaveGame.Player.TakeHit(dam, killer);
                    }
                    dam = 0;
                }
            }
            else if (dam > 0)
            {
                int b = Program.Rng.DiceRoll(5, dam) / 4;
                string s = seen ? "'s" : "s";
                SaveGame.MsgPrint($"You convert {mName}{s} pain into psychic energy!");
                b = Math.Min(SaveGame.Player.MaxMana, SaveGame.Player.Mana + b);
                SaveGame.Player.Mana = b;
                SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMana);
            }
            string noteDies = " collapses, a mindless husk.";
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
            SaveGame.Disturb(true);
            return true;
        }
    }
}