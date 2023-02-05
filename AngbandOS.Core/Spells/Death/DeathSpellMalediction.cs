// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death
{
    [Serializable]
    internal class DeathSpellMalediction : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.FireBall(new ProjectHellFire(saveGame), dir,
                Program.Rng.DiceRoll(3 + ((saveGame.Player.Level - 1) / 5), 3), 0);
            if (Program.Rng.DieRoll(5) != 1)
            {
                return;
            }
            int dummy = Program.Rng.DieRoll(1000);
            if (dummy == 666)
            {
                saveGame.FireBolt(new ProjectDeathRay(saveGame), dir, saveGame.Player.Level);
            }
            if (dummy < 500)
            {
                saveGame.FireBolt(new ProjectTurnAll(saveGame), dir, saveGame.Player.Level);
            }
            if (dummy < 800)
            {
                saveGame.FireBolt(new ProjectOldConf(saveGame), dir, saveGame.Player.Level);
            }
            saveGame.FireBolt(new ProjectStun(saveGame), dir, saveGame.Player.Level);
        }

        public override void Initialise(int characterClass)
        {
            Name = "Malediction";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 2;
                    ManaCost = 2;
                    BaseFailure = 25;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.Priest:
                    Level = 2;
                    ManaCost = 2;
                    BaseFailure = 25;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.Rogue:
                    Level = 7;
                    ManaCost = 4;
                    BaseFailure = 40;
                    FirstCastExperience = 1;
                    break;

                case CharacterClass.Ranger:
                    Level = 5;
                    ManaCost = 3;
                    BaseFailure = 40;
                    FirstCastExperience = 3;
                    break;

                case CharacterClass.Paladin:
                    Level = 3;
                    ManaCost = 3;
                    BaseFailure = 25;
                    FirstCastExperience = 1;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 2;
                    ManaCost = 2;
                    BaseFailure = 25;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.HighMage:
                    Level = 1;
                    ManaCost = 1;
                    BaseFailure = 20;
                    FirstCastExperience = 4;
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
            return $"dam {3 + ((player.Level - 1) / 5)}d3";
        }
    }
}