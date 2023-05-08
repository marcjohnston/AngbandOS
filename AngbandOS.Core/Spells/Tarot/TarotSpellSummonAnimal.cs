// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot
{
    [Serializable]
    internal class TarotSpellSummonAnimal : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.MsgPrint("You concentrate on the image of an animal...");
            if (Program.Rng.DieRoll(5) > 2)
            {
                if (!saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, new AnimalRangerMonsterSelector(), false))
                {
                    saveGame.MsgPrint("No-one ever turns up.");
                }
            }
            else if (saveGame.Level.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, new AnimalMonsterSelector()))
            {
                saveGame.MsgPrint("The summoned animal gets angry!");
            }
            else
            {
                saveGame.MsgPrint("No-one ever turns up.");
            }
        }

        public override string Name => "Summon Animal";
        public override void Initialise(int characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 24;
                    ManaCost = 22;
                    BaseFailure = 60;
                    FirstCastExperience = 8;
                    break;

                case CharacterClass.Priest:
                case CharacterClass.Monk:
                    Level = 26;
                    ManaCost = 24;
                    BaseFailure = 60;
                    FirstCastExperience = 8;
                    break;

                case CharacterClass.Rogue:
                    Level = 30;
                    ManaCost = 26;
                    BaseFailure = 60;
                    FirstCastExperience = 8;
                    break;

                case CharacterClass.Ranger:
                    Level = 28;
                    ManaCost = 25;
                    BaseFailure = 60;
                    FirstCastExperience = 8;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 28;
                    ManaCost = 25;
                    BaseFailure = 60;
                    FirstCastExperience = 8;
                    break;

                case CharacterClass.HighMage:
                    Level = 20;
                    ManaCost = 20;
                    BaseFailure = 50;
                    FirstCastExperience = 8;
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