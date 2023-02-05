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
    internal class NatureSpellWhirlpool : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.FireBall(new ProjectWater(saveGame), dir, 100 + saveGame.Player.Level, (saveGame.Player.Level / 12) + 1);
        }

        public override void Initialise(int characterClass)
        {
            Name = "Whirlpool";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 35;
                    ManaCost = 30;
                    BaseFailure = 85;
                    FirstCastExperience = 65;
                    break;

                case CharacterClass.Priest:
                    Level = 37;
                    ManaCost = 32;
                    BaseFailure = 85;
                    FirstCastExperience = 65;
                    break;

                case CharacterClass.Ranger:
                    Level = 36;
                    ManaCost = 33;
                    BaseFailure = 75;
                    FirstCastExperience = 45;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 38;
                    ManaCost = 38;
                    BaseFailure = 85;
                    FirstCastExperience = 65;
                    break;

                case CharacterClass.HighMage:
                case CharacterClass.Druid:
                    Level = 32;
                    ManaCost = 28;
                    BaseFailure = 75;
                    FirstCastExperience = 65;
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
            return $"dam {100 + player.Level}";
        }
    }
}