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
    internal class ProjectNuke : Projectile
    {
        public ProjectNuke(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BrightChartreuseSplat";

        protected override string EffectAnimation => "ChartreuseFlash";

        protected override bool AffectMonster(int who, int r, int y, int x, int dam)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            Monster mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            bool doPoly = false;
            string note = null;
            string noteDies = NoteDiesOrIsDestroyed(rPtr);
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
            if ((rPtr.Flags3 & MonsterFlag3.ImmunePoison) != 0)
            {
                note = " resists.";
                dam *= 3;
                dam /= Program.Rng.DieRoll(6) + 6;
                if (seen)
                {
                    rPtr.Knowledge.RFlags3 |= MonsterFlag3.ImmunePoison;
                }
            }
            else if (Program.Rng.DieRoll(3) == 1)
            {
                doPoly = true;
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
                int tmp = SaveGame.PolymorphMonster(mPtr.Race);
                if (tmp != mPtr.Race.Index)
                {
                    note = " changes!";
                    dam = 0;
                    SaveGame.Level.Monsters.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                    MonsterRace race = SaveGame.MonsterRaces[tmp];
                    SaveGame.Level.Monsters.PlaceMonsterAux(y, x, race, false, false, charm);
                    mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
                }
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
            if (dam > 1600)
            {
                dam = 1600;
            }
            dam = (dam + r) / (r + 1);
            Monster mPtr = SaveGame.Level.Monsters[who];
            string killer = mPtr.MonsterDesc(0x88);
            if (blind)
            {
                SaveGame.MsgPrint("You are hit by radiation!");
            }
            if (SaveGame.Player.HasPoisonResistance)
            {
                dam = ((2 * dam) + 2) / 5;
            }
            if (SaveGame.Player.TimedPoisonResistance != 0)
            {
                dam = ((2 * dam) + 2) / 5;
            }
            SaveGame.Player.TakeHit(dam, killer);
            if (!(SaveGame.Player.HasPoisonResistance || SaveGame.Player.TimedPoisonResistance != 0))
            {
                SaveGame.Player.SetTimedPoison(SaveGame.Player.TimedPoison + Program.Rng.RandomLessThan(dam) + 10);
                if (Program.Rng.DieRoll(5) == 1)
                {
                    SaveGame.MsgPrint("You undergo a freakish metamorphosis!");
                    if (Program.Rng.DieRoll(4) == 1)
                    {
                        SaveGame.Player.PolymorphSelf(SaveGame);
                    }
                    else
                    {
                        SaveGame.Player.ShuffleAbilityScores();
                    }
                }
                if (Program.Rng.DieRoll(6) == 1)
                {
                    SaveGame.Player.Inventory.InvenDamage(SaveGame.SetAcidDestroy, 2);
                }
            }
            return true;
        }
    }
}