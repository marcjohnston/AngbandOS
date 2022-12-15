// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.MonsterSelectors;
using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.Spells.Life
{
    [Serializable]
    internal class LifeSpellDivineIntervention : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.Project(0, 1, saveGame.Player.MapY, saveGame.Player.MapX, 777, new ProjectHolyFire(saveGame),
                ProjectionFlag.ProjectKill);
            saveGame.DispelMonsters(saveGame.Player.Level * 4);
            saveGame.SlowMonsters();
            saveGame.StunMonsters(saveGame.Player.Level * 4);
            saveGame.ConfuseMonsters(saveGame.Player.Level * 4);
            saveGame.TurnMonsters(saveGame.Player.Level * 4);
            saveGame.StasisMonsters(saveGame.Player.Level * 4);
            saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level, new CthuloidMonsterSelector(), true);
            saveGame.Player.SetTimedSuperheroism(saveGame.Player.TimedSuperheroism + Program.Rng.DieRoll(25) + 25);
            saveGame.Player.RestoreHealth(300);
            if (saveGame.Player.TimedHaste == 0)
            {
                saveGame.Player.SetTimedHaste(Program.Rng.DieRoll(20 + saveGame.Player.Level) + saveGame.Player.Level);
            }
            else
            {
                saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + Program.Rng.DieRoll(5));
            }
            saveGame.Player.SetTimedFear(0);
        }

        public override void Initialise(int characterClass)
        {
            Name = "Divine Intervention";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 48;
                    ManaCost = 50;
                    BaseFailure = 80;
                    FirstCastExperience = 100;
                    break;

                case CharacterClass.Priest:
                    Level = 40;
                    ManaCost = 40;
                    BaseFailure = 80;
                    FirstCastExperience = 200;
                    break;

                case CharacterClass.Paladin:
                    Level = 45;
                    ManaCost = 45;
                    BaseFailure = 80;
                    FirstCastExperience = 100;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 48;
                    ManaCost = 50;
                    BaseFailure = 80;
                    FirstCastExperience = 100;
                    break;

                case CharacterClass.HighMage:
                    Level = 45;
                    ManaCost = 60;
                    BaseFailure = 60;
                    FirstCastExperience = 100;
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
            return $"h300/d{player.Level * 4}+777";
        }
    }
}