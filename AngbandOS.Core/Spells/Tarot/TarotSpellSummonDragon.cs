// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.Spells.Tarot
{
    [Serializable]
    internal class TarotSpellSummonDragon : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.MsgPrint("You concentrate on the image of a dragon...");
            if (Program.Rng.DieRoll(10) > 3)
            {
                if (!saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, Constants.SummonDragon,
                    true))
                {
                    saveGame.MsgPrint("No-one ever turns up.");
                }
            }
            else if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, Constants.SummonDragon))
            {
                saveGame.MsgPrint("The summoned dragon gets angry!");
            }
            else
            {
                saveGame.MsgPrint("No-one ever turns up.");
            }
        }

        public override void Initialise(int characterClass)
        {
            Name = "Summon Dragon";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 39;
                    ManaCost = 80;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.Priest:
                case CharacterClass.Monk:
                    Level = 43;
                    ManaCost = 85;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.Rogue:
                    Level = 46;
                    ManaCost = 100;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.Ranger:
                    Level = 47;
                    ManaCost = 95;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 45;
                    ManaCost = 95;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.HighMage:
                    Level = 36;
                    ManaCost = 75;
                    BaseFailure = 70;
                    FirstCastExperience = 150;
                    break;

                default:
                    Level = 99;
                    ManaCost = 0;
                    BaseFailure = 0;
                    FirstCastExperience = 0;
                    break;
            }
        }

        protected override string Comment(Player player)
        {
            return "control 70%";
        }
    }
}