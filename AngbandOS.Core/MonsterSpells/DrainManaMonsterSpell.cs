﻿using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSpells
{
    [Serializable]
    internal class DrainManaMonsterSpell : MonsterSpell
    {
        /// <summary>
        /// Returns null, because the drain mana process cannot be seen.  If the player cannot see either monster, the player will not have
        /// any message indicating such.
        /// </summary>
        public override string? VsPlayerBlindMessage => null;

        /// <summary>
        /// Returns null, because the drain mana process cannot be seen.  If the player cannot see either monster, the player will not have
        /// any message indicating such.
        /// </summary>
        public override string? VsPlayerActionMessage(Monster monster) => null;

        /// <summary>
        /// Returns the message rendered to the player when a monster drains energy from another monster and the player sees it.
        /// </summary>
        public override string? VsMonsterSeenMessage(Monster monster, Monster target) => $"{monster.Name} draws psychic energy from {target.Name}.";

        public override bool DrainsMana => true;
        public override bool Annoys => true;

        public override void ExecuteOnPlayer(SaveGame saveGame, Monster monster)
        {
            string monsterName = monster.Name;
            bool playerIsBlind = saveGame.Player.TimedBlindness != 0;
            int monsterLevel = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            bool seenByPlayer = !playerIsBlind && monster.IsVisible;

            if (saveGame.Player.Mana != 0)
            {
                saveGame.MsgPrint($"{monsterName} draws psychic energy from you!");
                int r1 = (Program.Rng.DieRoll(monsterLevel) / 2) + 1;
                if (r1 >= saveGame.Player.Mana)
                {
                    r1 = saveGame.Player.Mana;
                    saveGame.Player.Mana = 0;
                    saveGame.Player.FractionalMana = 0;
                }
                else
                {
                    saveGame.Player.Mana -= r1;
                }
                saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMana);
                if (monster.Health < monster.MaxHealth)
                {
                    monster.Health += 6 * r1;
                    if (monster.Health > monster.MaxHealth)
                    {
                        monster.Health = monster.MaxHealth;
                    }
                    if (saveGame.TrackedMonsterIndex == monster.GetMonsterIndex(saveGame))
                    {
                        saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                    }
                    if (seenByPlayer)
                    {
                        saveGame.MsgPrint($"{monsterName} appears healthier.");
                    }
                }
            }
            saveGame.Level.Monsters.UpdateSmartLearn(monster, Constants.DrsMana);
        }

        public override void ExecuteOnMonster(SaveGame saveGame, Monster monster, Monster target)
        {
            int rlev = monster.Race.Level >= 1 ? monster.Race.Level : 1;
            bool playerIsBlind = saveGame.Player.TimedBlindness != 0;
            bool seen = !playerIsBlind && monster.IsVisible;
            string monsterName = monster.Name;
            string targetName = target.Name;
            bool blind = saveGame.Player.TimedBlindness != 0;
            bool seeTarget = !blind && target.IsVisible;
            bool seeBoth = seen && seeTarget;
            MonsterRace targetRace = target.Race;

            int r1 = (Program.Rng.DieRoll(rlev) / 2) + 1;
            if (monster.Health < monster.MaxHealth)
            {
                if (targetRace.Spells.Count == 0)
                {
                    if (seeBoth)
                    {
                        saveGame.MsgPrint($"{targetName} is unaffected!");
                    }
                }
                else
                {
                    monster.Health += 6 * r1;
                    if (monster.Health > monster.MaxHealth)
                    {
                        monster.Health = monster.MaxHealth;
                    }
                    if (saveGame.TrackedMonsterIndex == monster.GetMonsterIndex(saveGame))
                    {
                        saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                    }
                    if (seen)
                    {
                        saveGame.MsgPrint($"{monsterName} appears healthier.");
                    }
                }
            }
        }
    }
}