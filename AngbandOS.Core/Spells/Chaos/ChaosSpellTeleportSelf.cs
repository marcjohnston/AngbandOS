// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos
{
    [Serializable]
    internal class ChaosSpellTeleportSelf : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.TeleportPlayer(saveGame.Player.Level * 5);
        }

        public override string Name => "Teleport Self";
        public override void Initialise(int characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 15;
                    ManaCost = 9;
                    BaseFailure = 35;
                    FirstCastExperience = 5;
                    break;

                case CharacterClass.Priest:
                    Level = 17;
                    ManaCost = 11;
                    BaseFailure = 35;
                    FirstCastExperience = 5;
                    break;

                case CharacterClass.Ranger:
                    Level = 25;
                    ManaCost = 22;
                    BaseFailure = 60;
                    FirstCastExperience = 3;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Monk:
                    Level = 18;
                    ManaCost = 17;
                    BaseFailure = 35;
                    FirstCastExperience = 5;
                    break;

                case CharacterClass.Fanatic:
                    Level = 16;
                    ManaCost = 10;
                    BaseFailure = 35;
                    FirstCastExperience = 5;
                    break;

                case CharacterClass.HighMage:
                case CharacterClass.Cultist:
                    Level = 14;
                    ManaCost = 7;
                    BaseFailure = 25;
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
            return $"range {player.Level * 5}";
        }
    }
}