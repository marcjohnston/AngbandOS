// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;

namespace AngbandOS.Spells.Death
{
    [Serializable]
    internal class DeathSpellInvokeSpirits : Spell
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
            TargetEngine targetEngine = new TargetEngine(saveGame);
            int die = Program.Rng.DieRoll(100) + (saveGame.Player.Level / 5);
            if (!targetEngine.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.MsgPrint("You call on the power of the dead...");
            if (die > 100)
            {
                saveGame.MsgPrint("You feel a surge of eldritch force!");
            }
            if (die < 8)
            {
                saveGame.MsgPrint("Oh no! Mouldering forms rise from the earth around you!");
                saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty,
                    Constants.SummonUndead);
            }
            if (die < 14)
            {
                saveGame.MsgPrint("An unnamable evil brushes against your mind...");
                saveGame.Player.SetTimedFear(saveGame.Player.TimedFear + Program.Rng.DieRoll(4) + 4);
            }
            if (die < 26)
            {
                saveGame.MsgPrint("Your head is invaded by a horde of gibbering spectral voices...");
                saveGame.Player.SetTimedConfusion(saveGame.Player.TimedConfusion + Program.Rng.DieRoll(4) + 4);
            }
            if (die < 31)
            {
                saveGame.PolyMonster(dir);
            }
            if (die < 36)
            {
                saveGame.FireBoltOrBeam(beam - 10, new ProjectMissile(saveGame), dir,
                    Program.Rng.DiceRoll(3 + ((saveGame.Player.Level - 1) / 5), 4));
            }
            if (die < 41)
            {
                saveGame.ConfuseMonster(dir, saveGame.Player.Level);
            }
            if (die < 46)
            {
                saveGame.FireBall(new ProjectPois(saveGame), dir, 20 + (saveGame.Player.Level / 2), 3);
            }
            if (die < 51)
            {
                saveGame.LightLine(dir);
            }
            if (die < 56)
            {
                saveGame.FireBoltOrBeam(beam - 10, new ProjectElec(saveGame), dir,
                    Program.Rng.DiceRoll(3 + ((saveGame.Player.Level - 5) / 4), 8));
            }
            if (die < 61)
            {
                saveGame.FireBoltOrBeam(beam - 10, new ProjectCold(saveGame), dir,
                    Program.Rng.DiceRoll(5 + ((saveGame.Player.Level - 5) / 4), 8));
            }
            if (die < 66)
            {
                saveGame.FireBoltOrBeam(beam, new ProjectAcid(saveGame), dir,
                    Program.Rng.DiceRoll(6 + ((saveGame.Player.Level - 5) / 4), 8));
            }
            if (die < 71)
            {
                saveGame.FireBoltOrBeam(beam, new ProjectFire(saveGame), dir,
                    Program.Rng.DiceRoll(8 + ((saveGame.Player.Level - 5) / 4), 8));
            }
            if (die < 76)
            {
                saveGame.DrainLife(dir, 75);
            }
            if (die < 81)
            {
                saveGame.FireBall(new ProjectElec(saveGame), dir, 30 + (saveGame.Player.Level / 2), 2);
            }
            if (die < 86)
            {
                saveGame.FireBall(new ProjectAcid(saveGame), dir, 40 + saveGame.Player.Level, 2);
            }
            if (die < 91)
            {
                saveGame.FireBall(new ProjectIce(saveGame), dir, 70 + saveGame.Player.Level, 3);
            }
            if (die < 96)
            {
                saveGame.FireBall(new ProjectFire(saveGame), dir, 80 + saveGame.Player.Level, 3);
            }
            if (die < 101)
            {
                saveGame.DrainLife(dir, 100 + saveGame.Player.Level);
            }
            if (die < 104)
            {
                saveGame.Earthquake(saveGame.Player.MapY, saveGame.Player.MapX, 12);
            }
            if (die < 106)
            {
                saveGame.DestroyArea(saveGame.Player.MapY, saveGame.Player.MapX, 15);
            }
            if (die < 108)
            {
                saveGame.Carnage(true);
            }
            if (die < 110)
            {
                saveGame.DispelMonsters(120);
            }
            saveGame.DispelMonsters(150);
            saveGame.SlowMonsters();
            saveGame.SleepMonsters();
            saveGame.Player.RestoreHealth(300);
            if (die < 31)
            {
                saveGame.MsgPrint("Sepulchral voices chuckle. 'Soon you will join us, mortal.'");
            }
        }

        public override void Initialise(int characterClass)
        {
            Name = "Invoke Spirits";
            switch (characterClass)
            {
                case CharacterClass.Mage:
                    Level = 10;
                    ManaCost = 15;
                    BaseFailure = 80;
                    FirstCastExperience = 30;
                    break;

                case CharacterClass.Priest:
                    Level = 13;
                    ManaCost = 15;
                    BaseFailure = 80;
                    FirstCastExperience = 30;
                    break;

                case CharacterClass.Rogue:
                    Level = 23;
                    ManaCost = 20;
                    BaseFailure = 40;
                    FirstCastExperience = 20;
                    break;

                case CharacterClass.Ranger:
                    Level = 25;
                    ManaCost = 25;
                    BaseFailure = 80;
                    FirstCastExperience = 100;
                    break;

                case CharacterClass.Paladin:
                    Level = 15;
                    ManaCost = 20;
                    BaseFailure = 80;
                    FirstCastExperience = 30;
                    break;

                case CharacterClass.WarriorMage:
                case CharacterClass.Cultist:
                    Level = 12;
                    ManaCost = 18;
                    BaseFailure = 80;
                    FirstCastExperience = 30;
                    break;

                case CharacterClass.HighMage:
                    Level = 8;
                    ManaCost = 10;
                    BaseFailure = 70;
                    FirstCastExperience = 30;
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