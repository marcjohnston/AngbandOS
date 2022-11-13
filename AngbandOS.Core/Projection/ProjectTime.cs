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
    internal class ProjectTime : Projectile
    {
        public ProjectTime(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BrightGreenBolt";

        protected override string EffectAnimation => "BrightGreenCloud";

        protected override bool AffectMonster(int who, int r, int y, int x, int dam)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            Monster mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
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
            if (seen)
            {
                obvious = true;
            }
            if ((rPtr.Flags4 & MonsterFlag4.BreatheTime) != 0)
            {
                note = " resists.";
                dam *= 3;
                dam /= Program.Rng.DieRoll(6) + 6;
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
            int k = 0;
            bool blind = SaveGame.Player.TimedBlindness != 0;
            bool fuzzy = false;
            string act = null;
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
                SaveGame.MsgPrint("You are hit by a blast from the past!");
            }
            if (SaveGame.Player.HasTimeResistance)
            {
                dam *= 4;
                dam /= Program.Rng.DieRoll(6) + 6;
                SaveGame.MsgPrint("You feel as if time is passing you by.");
            }
            else
            {
                switch (Program.Rng.DieRoll(10))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        {
                            SaveGame.MsgPrint("You feel life has clocked back.");
                            SaveGame.Player.LoseExperience(100 + (SaveGame.Player.ExperiencePoints / 100 * Constants.MonDrainLife));
                            break;
                        }
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        {
                            switch (Program.Rng.DieRoll(6))
                            {
                                case 1:
                                    k = Ability.Strength;
                                    act = "strong";
                                    break;

                                case 2:
                                    k = Ability.Intelligence;
                                    act = "bright";
                                    break;

                                case 3:
                                    k = Ability.Wisdom;
                                    act = "wise";
                                    break;

                                case 4:
                                    k = Ability.Dexterity;
                                    act = "agile";
                                    break;

                                case 5:
                                    k = Ability.Constitution;
                                    act = "hale";
                                    break;

                                case 6:
                                    k = Ability.Charisma;
                                    act = "beautiful";
                                    break;
                            }
                            SaveGame.MsgPrint($"You're not as {act} as you used to be...");
                            SaveGame.Player.AbilityScores[k].Innate = SaveGame.Player.AbilityScores[k].Innate * 3 / 4;
                            if (SaveGame.Player.AbilityScores[k].Innate < 3)
                            {
                                SaveGame.Player.AbilityScores[k].Innate = 3;
                            }
                            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                            break;
                        }
                    case 10:
                        {
                            SaveGame.MsgPrint("You're not as powerful as you used to be...");
                            for (k = 0; k < 6; k++)
                            {
                                SaveGame.Player.AbilityScores[k].Innate = SaveGame.Player.AbilityScores[k].Innate * 3 / 4;
                                if (SaveGame.Player.AbilityScores[k].Innate < 3)
                                {
                                    SaveGame.Player.AbilityScores[k].Innate = 3;
                                }
                            }
                            SaveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                            break;
                        }
                }
            }
            SaveGame.Player.TakeHit(dam, killer);
            SaveGame.Disturb(true);
            return true;
        }
    }
}