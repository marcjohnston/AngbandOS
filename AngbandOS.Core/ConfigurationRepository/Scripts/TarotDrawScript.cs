// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TarotDrawScript : Script, IScript
{
    private TarotDrawScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool noneCame = false;
        int die = SaveGame.DieRoll(120);
        if (SaveGame.BaseCharacterClass.ID == CharacterClass.Rogue || SaveGame.BaseCharacterClass.ID == CharacterClass.HighMage)
        {
            die = SaveGame.DieRoll(110) + (SaveGame.ExperienceLevel / 5);
        }
        SaveGame.MsgPrint("You shuffle your Tarot deck and draw a card...");
        if (die < 7)
        {
            SaveGame.MsgPrint("Oh no! It's the Blasted Tower!");
            for (int dummy = 0; dummy < SaveGame.DieRoll(3); dummy++)
            {
                SaveGame.ActivateHiSummon();
            }
        }
        else if (die < 14)
        {
            SaveGame.MsgPrint("Oh no! It's the Devil!");
            SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(DemonMonsterFilter)));
        }
        else if (die < 18)
        {
            SaveGame.MsgPrint("Oh no! It's the Hanged Man.");
            SaveGame.ActivateDreadCurse();
        }
        else if (die < 22)
        {
            SaveGame.MsgPrint("It's the swords of discord.");
            SaveGame.AggravateMonsters();
        }
        else if (die < 26)
        {
            SaveGame.MsgPrint("It's the Fool.");
            SaveGame.TryDecreasingAbilityScore(Ability.Intelligence);
            SaveGame.TryDecreasingAbilityScore(Ability.Wisdom);
        }
        else if (die < 30)
        {
            SaveGame.MsgPrint("It's a picture of a strange monster.");

            if (!SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty * 3 / 2, SaveGame.GetRandomBizarreMonsterSelector()))
            {
                noneCame = true;
            }
        }
        else if (die < 33)
        {
            SaveGame.MsgPrint("It's the Moon.");
            SaveGame.UnlightArea(10, 3);
        }
        else if (die < 38)
        {
            SaveGame.MsgPrint("It's the Wheel of Fortune.");
            WildMagic(SaveGame, SaveGame.DieRoll(32) - 1);
        }
        else if (die < 40)
        {
            SaveGame.MsgPrint("It's a teleport card.");
            SaveGame.RunScriptInt(nameof(TeleportSelfScript), 10);
        }
        else if (die < 42)
        {
            SaveGame.MsgPrint("It's the Star.");
            SaveGame.TimedBlessing.AddTimer(SaveGame.ExperienceLevel);
        }
        else if (die < 47)
        {
            SaveGame.MsgPrint("It's a teleport card.");
            SaveGame.RunScriptInt(nameof(TeleportSelfScript), 100);
        }
        else if (die < 52)
        {
            SaveGame.MsgPrint("It's a teleport card.");
            SaveGame.RunScriptInt(nameof(TeleportSelfScript), 200);
        }
        else if (die < 60)
        {
            SaveGame.MsgPrint("It's the Tower.");
            SaveGame.WallBreaker();
        }
        else if (die < 72)
        {
            SaveGame.MsgPrint("It's Temperance.");
            SaveGame.SleepMonstersTouch();
        }
        else if (die < 80)
        {
            SaveGame.MsgPrint("It's the Tower.");
            SaveGame.Earthquake(SaveGame.MapY, SaveGame.MapX, 5);
        }
        else if (die < 82)
        {
            SaveGame.MsgPrint("It's a picture of a friendly monster.");
            if (!SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty * 3 / 2, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(Bizarre1MonsterFilter)), false))
            {
                noneCame = true;
            }
        }
        else if (die < 84)
        {
            SaveGame.MsgPrint("It's a picture of a friendly monster.");
            if (!SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty * 3 / 2, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(Bizarre2MonsterFilter)), false))
            {
                noneCame = true;
            }
        }
        else if (die < 86)
        {
            SaveGame.MsgPrint("It's a picture of a friendly monster.");
            if (!SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty * 3 / 2, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(Bizarre4MonsterFilter)), false))
            {
                noneCame = true;
            }
        }
        else if (die < 88)
        {
            SaveGame.MsgPrint("It's a picture of a friendly monster.");
            if (!SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty * 3 / 2, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(Bizarre5MonsterFilter)), false))
            {
                noneCame = true;
            }
        }
        else if (die < 96)
        {
            SaveGame.MsgPrint("It's the Lovers.");
            if (!SaveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            SaveGame.CharmMonster(dir, Math.Min(SaveGame.ExperienceLevel, 20));
        }
        else if (die < 101)
        {
            SaveGame.MsgPrint("It's the Hermit.");
            SaveGame.RunScript(nameof(WallOfStoneScript));
        }
        else if (die < 111)
        {
            SaveGame.MsgPrint("It's the Judgement.");
            SaveGame.RunScript(nameof(RerollHitPointsScript));
            if (SaveGame.HasMutations)
            {
                SaveGame.MsgPrint("You are cured of all mutations.");
                SaveGame.LoseAllMutations();
                SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
                SaveGame.HandleStuff();
            }
        }
        else if (die < 120)
        {
            SaveGame.MsgPrint("It's the Sun.");
            SaveGame.RunScript(nameof(LightScript));
        }
        else
        {
            SaveGame.MsgPrint("It's the World.");
            if (SaveGame.ExperiencePoints < Constants.PyMaxExp)
            {
                int ee = (SaveGame.ExperiencePoints / 25) + 1;
                if (ee > 5000)
                {
                    ee = 5000;
                }
                SaveGame.MsgPrint("You feel more experienced.");
                SaveGame.GainExperience(ee);
            }
        }
        if (noneCame)
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }

    private void WildMagic(SaveGame saveGame, int spell)
    {
        switch (SaveGame.DieRoll(spell) + SaveGame.DieRoll(8) + 1)
        {
            case 1:
            case 2:
            case 3:
                SaveGame.RunScriptInt(nameof(TeleportSelfScript), 10);
                break;

            case 4:
            case 5:
            case 6:
                SaveGame.RunScriptInt(nameof(TeleportSelfScript), 100);
                break;

            case 7:
            case 8:
                SaveGame.RunScriptInt(nameof(TeleportSelfScript), 200);
                break;

            case 9:
            case 10:
            case 11:
                SaveGame.UnlightArea(10, 3);
                break;

            case 12:
            case 13:
            case 14:
                SaveGame.LightArea(SaveGame.DiceRoll(2, 3), 2);
                break;

            case 15:
                SaveGame.RunScript(nameof(DestroyAdjacentDoorsScript));
                break;

            case 16:
            case 17:
                SaveGame.WallBreaker();
                break;

            case 18:
                SaveGame.SleepMonstersTouch();
                break;

            case 19:
            case 20:
                SaveGame.TrapCreation();
                break;

            case 21:
            case 22:
                SaveGame.RunScript(nameof(CreateDoorScript));
                break;

            case 23:
            case 24:
            case 25:
                SaveGame.AggravateMonsters();
                break;

            case 26:
                SaveGame.Earthquake(SaveGame.MapY, SaveGame.MapX, 5);
                break;

            case 27:
            case 28:
                SaveGame.RunScript(nameof(GainMutationScript));
                break;

            case 29:
            case 30:
                SaveGame.RunScript(nameof(ApplyDisenchantScript));
                break;

            case 31:
                SaveGame.LoseAllInfo();
                break;

            case 32:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ChaosProjectile)), 0, spell + 5, 1 + (spell / 10));
                break;

            case 33:
                SaveGame.RunScript(nameof(WallOfStoneScript));
                break;

            case 34:
            case 35:
                int counter = 0;
                while (counter++ < 8)
                {
                    SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.Difficulty * 3 / 2, SaveGame.GetRandomBizarreMonsterSelector());
                }
                break;

            case 36:
            case 37:
                SaveGame.ActivateHiSummon();
                break;

            case 38:
                SaveGame.SummonReaver();
                break;

            default:
                SaveGame.ActivateDreadCurse();
                break;
        }
    }
}
