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
    internal class NatureSpellFrostBolt : Spell
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
            saveGame.FireBoltOrBeam(beam - 10, new ColdProjectile(saveGame), dir,
                Program.Rng.DiceRoll(5 + ((saveGame.Player.Level - 5) / 4), 8));
        }

        public override string Name => "Frost Bolt";
        public override void Initialise(int characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 7;
                    ManaCost = 6;
                    BaseFailure = 40;
                    FirstCastExperience = 6;
                    break;

                case CharacterClass.Priest:
                    Level = 10;
                    ManaCost = 10;
                    BaseFailure = 40;
                    FirstCastExperience = 6;
                    break;

                case CharacterClass.Ranger:
                    Level = 12;
                    ManaCost = 9;
                    BaseFailure = 55;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 13;
                    ManaCost = 13;
                    BaseFailure = 40;
                    FirstCastExperience = 6;
                    break;

                case CharacterClass.HighMage:
                case CharacterClass.Druid:
                    Level = 5;
                    ManaCost = 5;
                    BaseFailure = 30;
                    FirstCastExperience = 6;
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
            return $"dam {5 + ((player.Level - 5) / 4)}d8";
        }
    }
}