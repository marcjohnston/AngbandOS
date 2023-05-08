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
    internal class LifeSpellHeroism : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.Player.TimedHeroism.AddTimer(Program.Rng.DieRoll(25) + 25);
            saveGame.Player.RestoreHealth(10);
            saveGame.Player.TimedFear.ResetTimer();
        }

        public override string Name => "Heroism";
        public override void Initialise(int characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 9;
                    ManaCost = 9;
                    BaseFailure = 50;
                    FirstCastExperience = 40;
                    break;

                case CharacterClass.Priest:
                    Level = 5;
                    ManaCost = 5;
                    BaseFailure = 80;
                    FirstCastExperience = 50;
                    break;

                case CharacterClass.Paladin:
                    Level = 9;
                    ManaCost = 9;
                    BaseFailure = 50;
                    FirstCastExperience = 40;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 10;
                    ManaCost = 10;
                    BaseFailure = 50;
                    FirstCastExperience = 40;
                    break;

                case CharacterClass.HighMage:
                    Level = 5;
                    ManaCost = 5;
                    BaseFailure = 50;
                    FirstCastExperience = 40;
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
            return "dur 25 + d25";
        }
    }
}