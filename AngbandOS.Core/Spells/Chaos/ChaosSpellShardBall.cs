// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.Spells.Chaos
{
    [Serializable]
    internal class ChaosSpellShardBall : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.FireBall(new ProjectShard(saveGame), dir, 120 + saveGame.Player.Level, 2);
        }

        public override void Initialise(int characterClass)
        {
            Name = "Shard Ball";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 43;
                    ManaCost = 44;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.Priest:
                    Level = 45;
                    ManaCost = 47;
                    BaseFailure = 90;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.Ranger:
                    Level = 50;
                    ManaCost = 50;
                    BaseFailure = 90;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Monk:
                    Level = 48;
                    ManaCost = 48;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.Fanatic:
                    Level = 43;
                    ManaCost = 44;
                    BaseFailure = 80;
                    FirstCastExperience = 150;
                    break;

                case CharacterClass.HighMage:
                case CharacterClass.Cultist:
                    Level = 38;
                    ManaCost = 38;
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
            return $"dam {120 + player.Level}";
        }
    }
}