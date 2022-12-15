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
    internal class ChaosSpellWonder : Spell
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
            int die = Program.Rng.DieRoll(100) + (saveGame.Player.Level / 5);
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            if (die > 100)
            {
                saveGame.MsgPrint("You feel a surge of power!");
            }
            if (die < 8)
            {
                saveGame.CloneMonster(dir);
            }
            else if (die < 14)
            {
                saveGame.SpeedMonster(dir);
            }
            else if (die < 26)
            {
                saveGame.HealMonster(dir);
            }
            else if (die < 31)
            {
                saveGame.PolyMonster(dir);
            }
            else if (die < 36)
            {
                saveGame.FireBoltOrBeam(beam - 10, new ProjectMissile(saveGame), dir,
                    Program.Rng.DiceRoll(3 + ((saveGame.Player.Level - 1) / 5), 4));
            }
            else if (die < 41)
            {
                saveGame.ConfuseMonster(dir, saveGame.Player.Level);
            }
            else if (die < 46)
            {
                saveGame.FireBall(new ProjectPois(saveGame), dir, 20 + (saveGame.Player.Level / 2), 3);
            }
            else if (die < 51)
            {
                saveGame.LightLine(dir);
            }
            else if (die < 56)
            {
                saveGame.FireBoltOrBeam(beam - 10, new ProjectElec(saveGame), dir,
                    Program.Rng.DiceRoll(3 + ((saveGame.Player.Level - 5) / 4), 8));
            }
            else if (die < 61)
            {
                saveGame.FireBoltOrBeam(beam - 10, new ProjectCold(saveGame), dir,
                    Program.Rng.DiceRoll(5 + ((saveGame.Player.Level - 5) / 4), 8));
            }
            else if (die < 66)
            {
                saveGame.FireBoltOrBeam(beam, new ProjectAcid(saveGame), dir,
                    Program.Rng.DiceRoll(6 + ((saveGame.Player.Level - 5) / 4), 8));
            }
            else if (die < 71)
            {
                saveGame.FireBoltOrBeam(beam, new ProjectFire(saveGame), dir,
                    Program.Rng.DiceRoll(8 + ((saveGame.Player.Level - 5) / 4), 8));
            }
            else if (die < 76)
            {
                saveGame.DrainLife(dir, 75);
            }
            else if (die < 81)
            {
                saveGame.FireBall(new ProjectElec(saveGame), dir, 30 + (saveGame.Player.Level / 2), 2);
            }
            else if (die < 86)
            {
                saveGame.FireBall(new ProjectAcid(saveGame), dir, 40 + saveGame.Player.Level, 2);
            }
            else if (die < 91)
            {
                saveGame.FireBall(new ProjectIce(saveGame), dir, 70 + saveGame.Player.Level, 3);
            }
            else if (die < 96)
            {
                saveGame.FireBall(new ProjectFire(saveGame), dir, 80 + saveGame.Player.Level, 3);
            }
            else if (die < 101)
            {
                saveGame.DrainLife(dir, 100 + saveGame.Player.Level);
            }
            else if (die < 104)
            {
                saveGame.Earthquake(saveGame.Player.MapY, saveGame.Player.MapX, 12);
            }
            else if (die < 106)
            {
                saveGame.DestroyArea(saveGame.Player.MapY, saveGame.Player.MapX, 15);
            }
            else if (die < 108)
            {
                saveGame.Carnage(true);
            }
            else if (die < 110)
            {
                saveGame.DispelMonsters(120);
            }
            else
            {
                saveGame.DispelMonsters(150);
                saveGame.SlowMonsters();
                saveGame.SleepMonsters();
                saveGame.Player.RestoreHealth(300);
            }
        }

        public override void Initialise(int characterClass)
        {
            Name = "Wonder";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 17;
                    ManaCost = 10;
                    BaseFailure = 25;
                    FirstCastExperience = 5;
                    break;

                case CharacterClass.Priest:
                    Level = 19;
                    ManaCost = 15;
                    BaseFailure = 50;
                    FirstCastExperience = 7;
                    break;

                case CharacterClass.Ranger:
                    Level = 27;
                    ManaCost = 23;
                    BaseFailure = 60;
                    FirstCastExperience = 5;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Monk:
                    Level = 21;
                    ManaCost = 21;
                    BaseFailure = 45;
                    FirstCastExperience = 7;
                    break;

                case CharacterClass.Fanatic:
                    Level = 19;
                    ManaCost = 12;
                    BaseFailure = 45;
                    FirstCastExperience = 7;
                    break;

                case CharacterClass.HighMage:
                case CharacterClass.Cultist:
                    Level = 15;
                    ManaCost = 9;
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
            return "random";
        }
    }
}