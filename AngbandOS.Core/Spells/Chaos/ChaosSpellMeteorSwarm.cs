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
    internal class ChaosSpellMeteorSwarm : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            int x = saveGame.Player.MapX;
            int y = saveGame.Player.MapY;
            int count = 0;
            int b = 10 + Program.Rng.DieRoll(10);
            for (int i = 0; i < b; i++)
            {
                int d;
                do
                {
                    count++;
                    if (count > 1000)
                    {
                        break;
                    }
                    x = saveGame.Player.MapX - 5 + Program.Rng.DieRoll(10);
                    y = saveGame.Player.MapY - 5 + Program.Rng.DieRoll(10);
                    int dx = saveGame.Player.MapX > x ? saveGame.Player.MapX - x : x - saveGame.Player.MapX;
                    int dy = saveGame.Player.MapY > y ? saveGame.Player.MapY - y : y - saveGame.Player.MapY;
                    d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
                } while (d > 5 || !saveGame.Level.PlayerHasLosBold(y, x));
                if (count > 1000)
                {
                    break;
                }
                count = 0;
                saveGame.Project(0, 2, y, x, saveGame.Player.Level * 3 / 2, new MeteorProjectile(saveGame),
                    ProjectionFlag.ProjectKill | ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem);
            }
        }

        public override string Name => "Meteor Swarm";
        public override void Initialise(int characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 35;
                    ManaCost = 32;
                    BaseFailure = 85;
                    FirstCastExperience = 35;
                    break;

                case CharacterClass.Priest:
                    Level = 37;
                    ManaCost = 37;
                    BaseFailure = 85;
                    FirstCastExperience = 35;
                    break;

                case CharacterClass.Ranger:
                    Level = 40;
                    ManaCost = 45;
                    BaseFailure = 85;
                    FirstCastExperience = 35;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Monk:
                    Level = 40;
                    ManaCost = 35;
                    BaseFailure = 85;
                    FirstCastExperience = 35;
                    break;

                case CharacterClass.Fanatic:
                    Level = 35;
                    ManaCost = 35;
                    BaseFailure = 85;
                    FirstCastExperience = 35;
                    break;

                case CharacterClass.HighMage:
                case CharacterClass.Cultist:
                    Level = 32;
                    ManaCost = 30;
                    BaseFailure = 75;
                    FirstCastExperience = 35;
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
            return $"dam {3 * player.Level / 2} each";
        }
    }
}