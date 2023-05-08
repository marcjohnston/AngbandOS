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
    internal class LifeSpellHolyOrb : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.FireBall(new HolyFireProjectile(saveGame), dir,
                Program.Rng.DiceRoll(3, 6) + saveGame.Player.Level + (saveGame.Player.Level /
                (saveGame.Player.BaseCharacterClass.ID == CharacterClass.Priest || saveGame.Player.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4)),
                saveGame.Player.Level < 30 ? 2 : 3);
        }

        public override string Name => "Holy Orb";
        public override void Initialise(int characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 20;
                    ManaCost = 20;
                    BaseFailure = 50;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.Priest:
                    Level = 10;
                    ManaCost = 8;
                    BaseFailure = 40;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.Paladin:
                    Level = 18;
                    ManaCost = 15;
                    BaseFailure = 50;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 26;
                    ManaCost = 26;
                    BaseFailure = 50;
                    FirstCastExperience = 4;
                    break;

                case CharacterClass.HighMage:
                    Level = 19;
                    ManaCost = 17;
                    BaseFailure = 40;
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
            int orb = player.Level / (player.BaseCharacterClass.ID == CharacterClass.Priest || player.BaseCharacterClass.ID == CharacterClass.HighMage
                          ? 2
                          : 4);
            return $" dam 3d6+{player.Level + orb}";
        }
    }
}