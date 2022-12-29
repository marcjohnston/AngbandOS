// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Spells.Folk
{
    [Serializable]
    internal class FolkSpellTeleportAway : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.FireBeam(new ProjectAwayAll(saveGame), dir, saveGame.Player.Level);
        }

        public override void Initialise(int characterClass)
        {
            Name = "Teleport Away";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 40;
                    ManaCost = 30;
                    BaseFailure = 70;
                    FirstCastExperience = 25;
                    break;

                case CharacterClass.Priest:
                    Level = 42;
                    ManaCost = 38;
                    BaseFailure = 70;
                    FirstCastExperience = 25;
                    break;

                case CharacterClass.Rogue:
                    Level = 46;
                    ManaCost = 40;
                    BaseFailure = 70;
                    FirstCastExperience = 25;
                    break;

                case CharacterClass.Ranger:
                    Level = 46;
                    ManaCost = 40;
                    BaseFailure = 70;
                    FirstCastExperience = 25;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 43;
                    ManaCost = 42;
                    BaseFailure = 70;
                    FirstCastExperience = 25;
                    break;

                case CharacterClass.HighMage:
                    Level = 38;
                    ManaCost = 28;
                    BaseFailure = 60;
                    FirstCastExperience = 25;
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