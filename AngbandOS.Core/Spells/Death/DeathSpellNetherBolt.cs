// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

namespace AngbandOS.Spells.Death
{
    [Serializable]
    internal class DeathSpellNetherBolt : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            int beam;
            switch (saveGame.Player.ProfessionIndex)
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
            saveGame.FireBoltOrBeam(beam, new ProjectNether(saveGame), dir,
                Program.Rng.DiceRoll(6 + ((saveGame.Player.Level - 5) / 4), 8));
        }

        public override void Initialise(int characterClass)
        {
            Name = "Nether Bolt";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 13;
                    ManaCost = 12;
                    BaseFailure = 30;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.Priest:
                    Level = 16;
                    ManaCost = 16;
                    BaseFailure = 30;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.Rogue:
                    Level = 23;
                    ManaCost = 23;
                    BaseFailure = 75;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.Ranger:
                    Level = 26;
                    ManaCost = 26;
                    BaseFailure = 50;
                    FirstCastExperience = 3;
                    break;

                case CharacterClass.Paladin:
                    Level = 19;
                    ManaCost = 19;
                    BaseFailure = 30;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 16;
                    ManaCost = 16;
                    BaseFailure = 30;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.HighMage:
                    Level = 11;
                    ManaCost = 10;
                    BaseFailure = 20;
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
            return $"dam {6 + ((player.Level - 5) / 4)}d8";
        }
    }
}