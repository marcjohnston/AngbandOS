// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot
{
    [Serializable]
    internal class TarotSpellTarotDraw : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            bool noneCame = false;
            int die = Program.Rng.DieRoll(120);
            if (saveGame.Player.BaseCharacterClass.ID == CharacterClass.Rogue || saveGame.Player.BaseCharacterClass.ID == CharacterClass.HighMage)
            {
                die = Program.Rng.DieRoll(110) + (saveGame.Player.Level / 5);
            }
            saveGame.MsgPrint("You shuffle your Tarot deck and draw a card...");
            if (die < 7)
            {
                saveGame.MsgPrint("Oh no! It's the Blasted Tower!");
                for (int dummy = 0; dummy < Program.Rng.DieRoll(3); dummy++)
                {
                    saveGame.ActivateHiSummon();
                }
            }
            else if (die < 14)
            {
                saveGame.MsgPrint("Oh no! It's the Devil!");
                saveGame.Level.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, new DemonMonsterSelector());
            }
            else if (die < 18)
            {
                saveGame.MsgPrint("Oh no! It's the Hanged Man.");
                saveGame.ActivateDreadCurse();
            }
            else if (die < 22)
            {
                saveGame.MsgPrint("It's the swords of discord.");
                saveGame.AggravateMonsters();
            }
            else if (die < 26)
            {
                saveGame.MsgPrint("It's the Fool.");
                saveGame.Player.TryDecreasingAbilityScore(Ability.Intelligence);
                saveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
            }
            else if (die < 30)
            {
                saveGame.MsgPrint("It's a picture of a strange monster.");

                if (!saveGame.Level.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty * 3 / 2, MonsterSelector.RandomBizarre()))
                {
                    noneCame = true;
                }
            }
            else if (die < 33)
            {
                saveGame.MsgPrint("It's the Moon.");
                saveGame.UnlightArea(10, 3);
            }
            else if (die < 38)
            {
                saveGame.MsgPrint("It's the Wheel of Fortune.");
                WildMagic(saveGame, Program.Rng.DieRoll(32) - 1);
            }
            else if (die < 40)
            {
                saveGame.MsgPrint("It's a teleport card.");
                saveGame.TeleportPlayer(10);
            }
            else if (die < 42)
            {
                saveGame.MsgPrint("It's the Star.");
                saveGame.Player.TimedBlessing.AddTimer(saveGame.Player.Level);
            }
            else if (die < 47)
            {
                saveGame.MsgPrint("It's a teleport card.");
                saveGame.TeleportPlayer(100);
            }
            else if (die < 52)
            {
                saveGame.MsgPrint("It's a teleport card.");
                saveGame.TeleportPlayer(200);
            }
            else if (die < 60)
            {
                saveGame.MsgPrint("It's the Tower.");
                saveGame.WallBreaker();
            }
            else if (die < 72)
            {
                saveGame.MsgPrint("It's Temperance.");
                saveGame.SleepMonstersTouch();
            }
            else if (die < 80)
            {
                saveGame.MsgPrint("It's the Tower.");
                saveGame.Earthquake(saveGame.Player.MapY, saveGame.Player.MapX, 5);
            }
            else if (die < 82)
            {
                saveGame.MsgPrint("It's a picture of a friendly monster.");
                if (!saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty * 3 / 2, new Bizarre1MonsterSelector(), false))
                {
                    noneCame = true;
                }
            }
            else if (die < 84)
            {
                saveGame.MsgPrint("It's a picture of a friendly monster.");
                if (!saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty * 3 / 2, new Bizarre2MonsterSelector(), false))
                {
                    noneCame = true;
                }
            }
            else if (die < 86)
            {
                saveGame.MsgPrint("It's a picture of a friendly monster.");
                if (!saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty * 3 / 2, new Bizarre4MonsterSelector(), false))
                {
                    noneCame = true;
                }
            }
            else if (die < 88)
            {
                saveGame.MsgPrint("It's a picture of a friendly monster.");
                if (!saveGame.Level.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty * 3 / 2, new Bizarre5MonsterSelector(), false))
                {
                    noneCame = true;
                }
            }
            else if (die < 96)
            {
                saveGame.MsgPrint("It's the Lovers.");
                if (!saveGame.GetDirectionWithAim(out int dir))
                {
                    return;
                }
                saveGame.CharmMonster(dir, Math.Min(saveGame.Player.Level, 20));
            }
            else if (die < 101)
            {
                saveGame.MsgPrint("It's the Hermit.");
                saveGame.WallStone();
            }
            else if (die < 111)
            {
                saveGame.MsgPrint("It's the Judgement.");
                saveGame.Player.RerollHitPoints();
                if (saveGame.Player.Dna.HasMutations)
                {
                    saveGame.MsgPrint("You are cured of all mutations.");
                    saveGame.Player.Dna.LoseAllMutations();
                    saveGame.UpdateBonusesFlaggedAction.Set();
                    saveGame.HandleStuff();
                }
            }
            else if (die < 120)
            {
                saveGame.MsgPrint("It's the Sun.");
                saveGame.Level.WizLight();
            }
            else
            {
                saveGame.MsgPrint("It's the World.");
                if (saveGame.Player.ExperiencePoints < Constants.PyMaxExp)
                {
                    int ee = (saveGame.Player.ExperiencePoints / 25) + 1;
                    if (ee > 5000)
                    {
                        ee = 5000;
                    }
                    saveGame.MsgPrint("You feel more experienced.");
                    saveGame.Player.GainExperience(ee);
                }
            }
            if (noneCame)
            {
                saveGame.MsgPrint("No-one ever turns up.");
            }
        }

        public override string Name => "Tarot Draw";
        
        protected override string Comment(Player player)
        {
            return "random";
        }

        private void WildMagic(SaveGame saveGame, int spell)
        {
            switch (Program.Rng.DieRoll(spell) + Program.Rng.DieRoll(8) + 1)
            {
                case 1:
                case 2:
                case 3:
                    saveGame.TeleportPlayer(10);
                    break;

                case 4:
                case 5:
                case 6:
                    saveGame.TeleportPlayer(100);
                    break;

                case 7:
                case 8:
                    saveGame.TeleportPlayer(200);
                    break;

                case 9:
                case 10:
                case 11:
                    saveGame.UnlightArea(10, 3);
                    break;

                case 12:
                case 13:
                case 14:
                    saveGame.LightArea(Program.Rng.DiceRoll(2, 3), 2);
                    break;

                case 15:
                    saveGame.DestroyDoorsTouch();
                    break;

                case 16:
                case 17:
                    saveGame.WallBreaker();
                    break;

                case 18:
                    saveGame.SleepMonstersTouch();
                    break;

                case 19:
                case 20:
                    saveGame.TrapCreation();
                    break;

                case 21:
                case 22:
                    saveGame.DoorCreation();
                    break;

                case 23:
                case 24:
                case 25:
                    saveGame.AggravateMonsters();
                    break;

                case 26:
                    saveGame.Earthquake(saveGame.Player.MapY, saveGame.Player.MapX, 5);
                    break;

                case 27:
                case 28:
                    saveGame.Player.Dna.GainMutation();
                    break;

                case 29:
                case 30:
                    saveGame.ApplyDisenchant();
                    break;

                case 31:
                    saveGame.LoseAllInfo();
                    break;

                case 32:
                    saveGame.FireBall(new ChaosProjectile(saveGame), 0, spell + 5, 1 + (spell / 10));
                    break;

                case 33:
                    saveGame.WallStone();
                    break;

                case 34:
                case 35:
                    int counter = 0;
                    while (counter++ < 8)
                    {
                        saveGame.Level.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty * 3 / 2, MonsterSelector.RandomBizarre());
                    }
                    break;

                case 36:
                case 37:
                    saveGame.ActivateHiSummon();
                    break;

                case 38:
                    saveGame.SummonReaver();
                    break;

                default:
                    saveGame.ActivateDreadCurse();
                    break;
            }
        }
    }
}