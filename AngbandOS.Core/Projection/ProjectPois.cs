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
    internal class ProjectPois : Projectile
    {
        public ProjectPois(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "GreenBullet";

        protected override string ImpactGraphic => "GreenSplat";

        protected override string EffectAnimation => "GreenCloud";

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string note = null;
            string noteDies = NoteDiesOrIsDestroyed(rPtr);
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
                note = " resists a lot.";
                dam /= 9;
                if (seen)
                {
                    rPtr.Knowledge.RFlags3 |= MonsterFlag3.ImmunePoison;
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
                SaveGame.MsgPrint("You are hit by poison!");
            }
            if (SaveGame.Player.HasPoisonResistance)
            {
                dam = (dam + 2) / 3;
            }
            if (SaveGame.Player.TimedPoisonResistance != 0)
            {
                dam = (dam + 2) / 3;
            }
            if (!(SaveGame.Player.TimedPoisonResistance != 0 || SaveGame.Player.HasPoisonResistance) &&
                Program.Rng.DieRoll(SaveGame.HurtChance) == 1)
            {
                SaveGame.Player.TryDecreasingAbilityScore(Ability.Constitution);
            }
            SaveGame.Player.TakeHit(dam, killer);
            if (!(SaveGame.Player.HasPoisonResistance || SaveGame.Player.TimedPoisonResistance != 0))
            {
                if (Program.Rng.DieRoll(10) <= SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                {
                    SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
                }
                else
                {
                    SaveGame.Player.SetTimedPoison(SaveGame.Player.TimedPoison + Program.Rng.RandomLessThan(dam) + 10);
                }
            }
            return true;
        }
    }
}