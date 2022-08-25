// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.Enumerations;
using Cthangband.StaticData;
using AngbandOS.Interface;

namespace Cthangband.Projection
{
    internal class ProjectChaos : Projectile
    {
        public ProjectChaos(SaveGame saveGame) : base(saveGame)
        {
            BoltGraphic = "PurpleBullet";
            ImpactGraphic = "PurpleSplat";
            EffectAnimation = "PinkPurpleFlash";
        }

        protected override bool AffectFloor(int y, int x)
        {
            return true;
        }

        protected override bool AffectItem(int who, int y, int x)
        {
            GridTile cPtr = Level.Grid[y][x];
            int nextOIdx;
            bool obvious = false;
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            string oName = "";
            for (int thisOIdx = cPtr.ItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
            {
                bool isArt = false;
                bool ignore = false;
                bool plural = false;
                Item oPtr = Level.Items[thisOIdx];
                nextOIdx = oPtr.NextInStack;
                oPtr.GetMergedFlags(f1, f2, f3);
                if (oPtr.Count > 1)
                {
                    plural = true;
                }
                if (oPtr.IsFixedArtifact() || string.IsNullOrEmpty(oPtr.RandartName) == false)
                {
                    isArt = true;
                }
                string noteKill = plural ? " are destroyed!" : " is destroyed!";
                if (f2.IsSet(ItemFlag2.ResChaos))
                {
                    ignore = true;
                }
                if (oPtr.Marked)
                {
                    obvious = true;
                    oName = oPtr.Description(false, 0);
                }
                if (isArt || ignore)
                {
                    if (oPtr.Marked)
                    {
                        string s = plural ? "are" : "is";
                        SaveGame.MsgPrint($"The {oName} {s} unaffected!");
                    }
                }
                else
                {
                    if (oPtr.Marked && string.IsNullOrEmpty(noteKill))
                    {
                        SaveGame.MsgPrint($"The {oName}{noteKill}");
                    }
                    int oSval = oPtr.ItemSubCategory;
                    bool isPotion = oPtr.ItemType.Category == ItemCategory.Potion;
                    Level.DeleteObjectIdx(thisOIdx);
                    if (isPotion)
                    {
                        SaveGame.PotionSmashEffect(who, y, x, oSval);
                    }
                    Level.RedrawSingleLocation(y, x);
                }
            }
            return obvious;
        }

        protected override bool AffectMonster(int who, int r, int y, int x, int dam)
        {
            int tmp;
            GridTile cPtr = Level.Grid[y][x];
            Monster mPtr = Level.Monsters[cPtr.MonsterIndex];
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
                SaveGame.MsgPrint($"{mName} gets angry!");
                mPtr.Mind &= ~Constants.SmFriendly;
            }
            if (seen)
            {
                obvious = true;
            }
            bool doPoly = true;
            int doConf = (5 + Program.Rng.DieRoll(11) + r) / (r + 1);
            if ((rPtr.Flags4 & MonsterFlag4.BreatheChaos) != 0 ||
                ((rPtr.Flags3 & MonsterFlag3.Demon) != 0 && Program.Rng.DieRoll(3) == 1))
            {
                note = " resists.";
                dam *= 3;
                dam /= Program.Rng.DieRoll(6) + 6;
                doPoly = false;
            }
            if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
            {
                doPoly = false;
            }
            if ((rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
            {
                doPoly = false;
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
            else if (doPoly && Program.Rng.DieRoll(90) > rPtr.Level)
            {
                note = " is unaffected!";
                bool charm = (mPtr.Mind & Constants.SmFriendly) != 0;
                tmp = SaveGame.PolymorphMonster(mPtr.Race);
                if (tmp != mPtr.Race.Index)
                {
                    note = " changes!";
                    dam = 0;
                    Level.Monsters.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                    MonsterRace race = SaveGame.MonsterRaces[tmp];
                    Level.Monsters.PlaceMonsterAux(y, x, race, false, false, charm);
                    mPtr = Level.Monsters[cPtr.MonsterIndex];
                }
            }
            else if (doConf != 0 && (rPtr.Flags3 & MonsterFlag3.ImmuneConfusion) == 0 &&
                     (rPtr.Flags4 & MonsterFlag4.BreatheConfusion) == 0 && (rPtr.Flags4 & MonsterFlag4.BreatheChaos) == 0)
            {
                if (mPtr.ConfusionLevel != 0)
                {
                    note = " looks more confused.";
                    tmp = mPtr.ConfusionLevel + (doConf / 2);
                }
                else
                {
                    note = " looks confused.";
                    tmp = doConf;
                }
                mPtr.ConfusionLevel = tmp < 200 ? tmp : 200;
            }
            if (who != 0)
            {
                if (SaveGame.TrackedMonsterIndex == cPtr.MonsterIndex)
                {
                    Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                }
                mPtr.SleepLevel = 0;
                mPtr.Health -= dam;
                if (mPtr.Health < 0)
                {
                    bool sad = (mPtr.Mind & Constants.SmFriendly) != 0 && !mPtr.IsVisible;
                    SaveGame.MonsterDeath(cPtr.MonsterIndex);
                    Level.Monsters.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
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
                        Level.Monsters.MessagePain(cPtr.MonsterIndex, dam);
                    }
                }
            }
            else
            {
                if (Level.Monsters.DamageMonster(cPtr.MonsterIndex, dam, out bool fear, noteDies))
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
                        Level.Monsters.MessagePain(cPtr.MonsterIndex, dam);
                    }
                    if (fear && mPtr.IsVisible)
                    {
                        SaveGame.PlaySound(SoundEffect.MonsterFlees);
                        SaveGame.MsgPrint($"{mName} flees in terror!");
                    }
                }
            }
            Level.Monsters.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
            Level.RedrawSingleLocation(y, x);
            ProjectMn++;
            ProjectMx = x;
            ProjectMy = y;
            return obvious;
        }

        protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
        {
            bool blind = Player.TimedBlindness != 0;
            bool fuzzy = false;
            if (x != Player.MapX || y != Player.MapY)
            {
                return false;
            }
            if (who == 0)
            {
                return false;
            }
            if (Player.HasReflection && aRad == 0 && Program.Rng.DieRoll(10) != 1)
            {
                int tY;
                int tX;
                int maxAttempts = 10;
                SaveGame.MsgPrint(blind ? "Something bounces!" : "The attack bounces!");
                do
                {
                    tY = Level.Monsters[who].MapY - 1 + Program.Rng.DieRoll(3);
                    tX = Level.Monsters[who].MapX - 1 + Program.Rng.DieRoll(3);
                    maxAttempts--;
                } while (maxAttempts > 0 && Level.InBounds2(tY, tX) && !Level.PlayerHasLosBold(tY, tX));
                if (maxAttempts < 1)
                {
                    tY = Level.Monsters[who].MapY;
                    tX = Level.Monsters[who].MapX;
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
            Monster mPtr = Level.Monsters[who];
            string killer = mPtr.MonsterDesc(0x88);
            if (fuzzy)
            {
                SaveGame.MsgPrint("You are hit by a wave of anarchy!");
            }
            if (Player.HasChaosResistance)
            {
                dam *= 6;
                dam /= Program.Rng.DieRoll(6) + 6;
            }
            if (!Player.HasConfusionResistance)
            {
                Player.SetTimedConfusion(Player.TimedConfusion + Program.Rng.RandomLessThan(20) + 10);
            }
            if (!Player.HasChaosResistance)
            {
                Player.SetTimedHallucinations(Player.TimedHallucinations + Program.Rng.DieRoll(10));
                if (Program.Rng.DieRoll(3) == 1)
                {
                    SaveGame.MsgPrint("Your body is twisted by chaos!");
                    Player.Dna.GainMutation(SaveGame);
                }
            }
            if (!Player.HasNetherResistance && !Player.HasChaosResistance)
            {
                if (Player.HasHoldLife && Program.Rng.RandomLessThan(100) < 75)
                {
                    SaveGame.MsgPrint("You keep hold of your life force!");
                }
                else if (Program.Rng.DieRoll(10) <= Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                {
                    SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
                }
                else if (Player.HasHoldLife)
                {
                    SaveGame.MsgPrint("You feel your life slipping away!");
                    Player.LoseExperience(500 + (Player.ExperiencePoints / 1000 * Constants.MonDrainLife));
                }
                else
                {
                    SaveGame.MsgPrint("You feel your life draining away!");
                    Player.LoseExperience(5000 + (Player.ExperiencePoints / 100 * Constants.MonDrainLife));
                }
            }
            if (!Player.HasChaosResistance || Program.Rng.DieRoll(9) == 1)
            {
                Player.Inventory.InvenDamage(SaveGame.SetElecDestroy, 2);
                Player.Inventory.InvenDamage(SaveGame.SetFireDestroy, 2);
            }
            Player.TakeHit(dam, killer);
            SaveGame.Disturb(true);
            return true;
        }
    }
}