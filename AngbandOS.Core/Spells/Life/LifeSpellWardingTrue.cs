// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life
{
    [Serializable]
    internal class LifeSpellWardingTrue : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.ElderSign();
            saveGame.ElderSignCreation();
        }

        public override string Name => "Warding True";
        public override void Initialise(int characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 46;
                    ManaCost = 70;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.Priest:
                    Level = 44;
                    ManaCost = 44;
                    BaseFailure = 80;
                    FirstCastExperience = 250;
                    break;

                case CharacterClass.Paladin:
                    Level = 46;
                    ManaCost = 60;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 50;
                    ManaCost = 70;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.HighMage:
                    Level = 40;
                    ManaCost = 70;
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
            return string.Empty;
        }
    }
}