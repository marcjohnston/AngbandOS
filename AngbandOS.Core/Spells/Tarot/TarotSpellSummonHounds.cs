// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.Spells.Tarot
{
    [Serializable]
    internal class TarotSpellSummonHounds : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.MsgPrint("You concentrate on the image of a hound...");
            if (Program.Rng.DieRoll(5) > 2)
            {
                if (!saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, Constants.SummonHound,
                    true))
                {
                    saveGame.MsgPrint("No-one ever turns up.");
                }
            }
            else if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, Constants.SummonHound))
            {
                saveGame.MsgPrint("The summoned hounds get angry!");
            }
            else
            {
                saveGame.MsgPrint("No-one ever turns up.");
            }
        }

        public override void Initialise(int characterClass)
        {
            Name = "Summon Hounds";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 30;
                    ManaCost = 30;
                    BaseFailure = 70;
                    FirstCastExperience = 35;
                    break;

                case CharacterClass.Priest:
                case CharacterClass.Monk:
                    Level = 33;
                    ManaCost = 30;
                    BaseFailure = 70;
                    FirstCastExperience = 35;
                    break;

                case CharacterClass.Rogue:
                    Level = 38;
                    ManaCost = 33;
                    BaseFailure = 70;
                    FirstCastExperience = 35;
                    break;

                case CharacterClass.Ranger:
                    Level = 36;
                    ManaCost = 33;
                    BaseFailure = 70;
                    FirstCastExperience = 35;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 35;
                    ManaCost = 33;
                    BaseFailure = 70;
                    FirstCastExperience = 35;
                    break;

                case CharacterClass.HighMage:
                    Level = 25;
                    ManaCost = 25;
                    BaseFailure = 60;
                    FirstCastExperience = 35;
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
            return "control 60%";
        }
    }
}