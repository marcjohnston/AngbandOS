﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TarotDrawScript : Script, IScript
{
    private TarotDrawScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool noneCame = false;
        int die = Game.DieRoll(120);
        if (Game.BaseCharacterClass.ID == CharacterClass.Rogue || Game.BaseCharacterClass.ID == CharacterClass.HighMage)
        {
            die = Game.DieRoll(110) + (Game.ExperienceLevel.Value / 5);
        }
        Game.MsgPrint("You shuffle your Tarot deck and draw a card...");
        if (die < 7)
        {
            Game.MsgPrint("Oh no! It's the Blasted Tower!");
            for (int dummy = 0; dummy < Game.DieRoll(3); dummy++)
            {
                Game.ActivateHiSummon();
            }
        }
        else if (die < 14)
        {
            Game.MsgPrint("Oh no! It's the Devil!");
            Game.SummonSpecific(Game.MapY.Value, Game.MapX.Value, Game.Difficulty, Game.SingletonRepository.MonsterFilters.Get(nameof(DemonMonsterFilter)));
        }
        else if (die < 18)
        {
            Game.MsgPrint("Oh no! It's the Hanged Man.");
            Game.ActivateDreadCurse();
        }
        else if (die < 22)
        {
            Game.MsgPrint("It's the swords of discord.");
            Game.AggravateMonsters();
        }
        else if (die < 26)
        {
            Game.MsgPrint("It's the Fool.");
            Game.TryDecreasingAbilityScore(Ability.Intelligence);
            Game.TryDecreasingAbilityScore(Ability.Wisdom);
        }
        else if (die < 30)
        {
            Game.MsgPrint("It's a picture of a strange monster.");

            if (!Game.SummonSpecific(Game.MapY.Value, Game.MapX.Value, Game.Difficulty * 3 / 2, Game.GetRandomBizarreMonsterSelector()))
            {
                noneCame = true;
            }
        }
        else if (die < 33)
        {
            Game.MsgPrint("It's the Moon.");
            Game.UnlightArea(10, 3);
        }
        else if (die < 38)
        {
            Game.MsgPrint("It's the Wheel of Fortune.");
            WildMagic(Game, Game.DieRoll(32) - 1);
        }
        else if (die < 40)
        {
            Game.MsgPrint("It's a teleport card.");
            Game.RunScriptInt(nameof(TeleportSelfScript), 10);
        }
        else if (die < 42)
        {
            Game.MsgPrint("It's the Star.");
            Game.BlessingTimer.AddTimer(Game.ExperienceLevel.Value);
        }
        else if (die < 47)
        {
            Game.MsgPrint("It's a teleport card.");
            Game.RunScriptInt(nameof(TeleportSelfScript), 100);
        }
        else if (die < 52)
        {
            Game.MsgPrint("It's a teleport card.");
            Game.RunScriptInt(nameof(TeleportSelfScript), 200);
        }
        else if (die < 60)
        {
            Game.MsgPrint("It's the Tower.");
            Game.WallBreaker();
        }
        else if (die < 72)
        {
            Game.MsgPrint("It's Temperance.");
            Game.SleepMonstersTouch();
        }
        else if (die < 80)
        {
            Game.MsgPrint("It's the Tower.");
            Game.Earthquake(Game.MapY.Value, Game.MapX.Value, 5);
        }
        else if (die < 82)
        {
            Game.MsgPrint("It's a picture of a friendly monster.");
            if (!Game.SummonSpecificFriendly(Game.MapY.Value, Game.MapX.Value, Game.Difficulty * 3 / 2, Game.SingletonRepository.MonsterFilters.Get(nameof(Bizarre1MonsterFilter)), false))
            {
                noneCame = true;
            }
        }
        else if (die < 84)
        {
            Game.MsgPrint("It's a picture of a friendly monster.");
            if (!Game.SummonSpecificFriendly(Game.MapY.Value, Game.MapX.Value, Game.Difficulty * 3 / 2, Game.SingletonRepository.MonsterFilters.Get(nameof(Bizarre2MonsterFilter)), false))
            {
                noneCame = true;
            }
        }
        else if (die < 86)
        {
            Game.MsgPrint("It's a picture of a friendly monster.");
            if (!Game.SummonSpecificFriendly(Game.MapY.Value, Game.MapX.Value, Game.Difficulty * 3 / 2, Game.SingletonRepository.MonsterFilters.Get(nameof(Bizarre4MonsterFilter)), false))
            {
                noneCame = true;
            }
        }
        else if (die < 88)
        {
            Game.MsgPrint("It's a picture of a friendly monster.");
            if (!Game.SummonSpecificFriendly(Game.MapY.Value, Game.MapX.Value, Game.Difficulty * 3 / 2, Game.SingletonRepository.MonsterFilters.Get(nameof(Bizarre5MonsterFilter)), false))
            {
                noneCame = true;
            }
        }
        else if (die < 96)
        {
            Game.MsgPrint("It's the Lovers.");
            if (!Game.GetDirectionWithAim(out int dir))
            {
                return;
            }
            Game.CharmMonster(dir, Math.Min(Game.ExperienceLevel.Value, 20));
        }
        else if (die < 101)
        {
            Game.MsgPrint("It's the Hermit.");
            Game.RunScript(nameof(WallOfStoneScript));
        }
        else if (die < 111)
        {
            Game.MsgPrint("It's the Judgement.");
            Game.RunScript(nameof(RerollHitPointsScript));
            if (Game.HasMutations)
            {
                Game.MsgPrint("You are cured of all mutations.");
                Game.LoseAllMutations();
                Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
                Game.HandleStuff();
            }
        }
        else if (die < 120)
        {
            Game.MsgPrint("It's the Sun.");
            Game.RunScript(nameof(LightScript));
        }
        else
        {
            Game.MsgPrint("It's the World.");
            if (Game.ExperiencePoints.Value < Constants.PyMaxExp)
            {
                int ee = (Game.ExperiencePoints.Value / 25) + 1;
                if (ee > 5000)
                {
                    ee = 5000;
                }
                Game.MsgPrint("You feel more experienced.");
                Game.GainExperience(ee);
            }
        }
        if (noneCame)
        {
            Game.MsgPrint("No-one ever turns up.");
        }
    }

    private void WildMagic(Game game, int spell)
    {
        switch (Game.DieRoll(spell) + Game.DieRoll(8) + 1)
        {
            case 1:
            case 2:
            case 3:
                Game.RunScriptInt(nameof(TeleportSelfScript), 10);
                break;

            case 4:
            case 5:
            case 6:
                Game.RunScriptInt(nameof(TeleportSelfScript), 100);
                break;

            case 7:
            case 8:
                Game.RunScriptInt(nameof(TeleportSelfScript), 200);
                break;

            case 9:
            case 10:
            case 11:
                Game.UnlightArea(10, 3);
                break;

            case 12:
            case 13:
            case 14:
                Game.LightArea(Game.DiceRoll(2, 3), 2);
                break;

            case 15:
                Game.RunScript(nameof(DestroyAdjacentDoorsScript));
                break;

            case 16:
            case 17:
                Game.WallBreaker();
                break;

            case 18:
                Game.SleepMonstersTouch();
                break;

            case 19:
            case 20:
                Game.TrapCreation();
                break;

            case 21:
            case 22:
                Game.RunScript(nameof(CreateDoorScript));
                break;

            case 23:
            case 24:
            case 25:
                Game.AggravateMonsters();
                break;

            case 26:
                Game.Earthquake(Game.MapY.Value, Game.MapX.Value, 5);
                break;

            case 27:
            case 28:
                Game.RunScript(nameof(GainMutationScript));
                break;

            case 29:
            case 30:
                Game.RunScript(nameof(ApplyDisenchantScript));
                break;

            case 31:
                Game.LoseAllInfo();
                break;

            case 32:
                Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(ChaosProjectile)), 0, spell + 5, 1 + (spell / 10));
                break;

            case 33:
                Game.RunScript(nameof(WallOfStoneScript));
                break;

            case 34:
            case 35:
                int counter = 0;
                while (counter++ < 8)
                {
                    Game.SummonSpecific(Game.MapY.Value, Game.MapX.Value, Game.Difficulty * 3 / 2, Game.GetRandomBizarreMonsterSelector());
                }
                break;

            case 36:
            case 37:
                Game.ActivateHiSummon();
                break;

            case 38:
                Game.SummonReaver();
                break;

            default:
                Game.ActivateDreadCurse();
                break;
        }
    }
}