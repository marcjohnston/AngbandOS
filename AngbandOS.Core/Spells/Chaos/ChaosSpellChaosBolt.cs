// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Spells.Chaos
{
    [Serializable]
    internal class ChaosSpellChaosBolt : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            int beam;
            switch (saveGame.Player.BaseCharacterClass.ID)
            {
                case CharacterClass.Mage:
                    beam = saveGame.Player.Level;
                    break;

                case CharacterClass.HighMage:
                    beam = saveGame.Player.Level + 10;
                    break;

                default:
                    beam = saveGame.Player.Level / 2;
                    break;
            }
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.FireBoltOrBeam(beam, new ProjectChaos(saveGame), dir,
                Program.Rng.DiceRoll(10 + ((saveGame.Player.Level - 5) / 4), 8));
        }

        public override void Initialise(int characterClass)
        {
            Name = "Chaos Bolt";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 19;
                    ManaCost = 12;
                    BaseFailure = 45;
                    FirstCastExperience = 9;
                    break;

                case CharacterClass.Priest:
                    Level = 21;
                    ManaCost = 16;
                    BaseFailure = 50;
                    FirstCastExperience = 9;
                    break;

                case CharacterClass.Ranger:
                    Level = 30;
                    ManaCost = 25;
                    BaseFailure = 60;
                    FirstCastExperience = 8;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Monk:
                    Level = 23;
                    ManaCost = 22;
                    BaseFailure = 45;
                    FirstCastExperience = 9;
                    break;

                case CharacterClass.Fanatic:
                    Level = 22;
                    ManaCost = 14;
                    BaseFailure = 45;
                    FirstCastExperience = 9;
                    break;

                case CharacterClass.HighMage:
                case CharacterClass.Cultist:
                    Level = 17;
                    ManaCost = 10;
                    BaseFailure = 35;
                    FirstCastExperience = 9;
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
            return $"dam {10 + ((player.Level - 5) / 4)}d8";
        }
    }
}