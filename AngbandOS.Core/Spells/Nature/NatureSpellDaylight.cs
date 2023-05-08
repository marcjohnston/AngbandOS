// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature
{
    [Serializable]
    internal class NatureSpellDaylight : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.LightArea(Program.Rng.DiceRoll(2, saveGame.Player.Level / 2), (saveGame.Player.Level / 10) + 1);
            if (!saveGame.Player.Race.IsBurnedBySunlight || saveGame.Player.HasLightResistance)
            {
                return;
            }
            saveGame.MsgPrint("The daylight scorches your flesh!");
            saveGame.Player.TakeHit(Program.Rng.DiceRoll(2, 2), "daylight");
        }

        public override string Name => "Daylight";
        public override void Initialise(int characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 4;
                    ManaCost = 4;
                    BaseFailure = 50;
                    FirstCastExperience = 5;
                    break;

                case CharacterClass.Priest:
                    Level = 6;
                    ManaCost = 5;
                    BaseFailure = 50;
                    FirstCastExperience = 5;
                    break;

                case CharacterClass.Ranger:
                    Level = 6;
                    ManaCost = 7;
                    BaseFailure = 50;
                    FirstCastExperience = 3;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 6;
                    ManaCost = 6;
                    BaseFailure = 50;
                    FirstCastExperience = 5;
                    break;

                case CharacterClass.HighMage:
                case CharacterClass.Druid:
                    Level = 3;
                    ManaCost = 3;
                    BaseFailure = 40;
                    FirstCastExperience = 5;
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
            return $"dam 2d{player.Level / 2}";
        }
    }
}