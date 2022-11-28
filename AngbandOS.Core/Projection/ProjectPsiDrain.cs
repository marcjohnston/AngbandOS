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

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            // Only stupid friends are affected.
            MonsterRace rPtr = mPtr.Race;
            return rPtr.EmptyMind;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string note = null;
            string mName = mPtr.MonsterDesc(0);
            if (seen)
            {
                obvious = true;
            }
            if (rPtr.EmptyMind)
            {
                dam = 0;
                note = " is immune!";
            }
            else if (rPtr.Stupid || rPtr.WeirdMind ||
                     rPtr.Animal || rPtr.Level > Program.Rng.DieRoll(3 * dam))
            {
                dam /= 3;
                note = " resists.";
                if ((rPtr.Undead || rPtr.Demon) &&
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
    }
}