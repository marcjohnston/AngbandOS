// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellTarotDraw : Spell
{
    private TarotSpellTarotDraw(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        bool noneCame = false;
        int die = Program.Rng.DieRoll(120);
        if (SaveGame.Player.BaseCharacterClass.ID == CharacterClass.Rogue || SaveGame.Player.BaseCharacterClass.ID == CharacterClass.HighMage)
        {
            die = Program.Rng.DieRoll(110) + (SaveGame.Player.ExperienceLevel / 5);
        }
        SaveGame.MsgPrint("You shuffle your Tarot deck and draw a card...");
        if (die < 7)
        {
            SaveGame.MsgPrint("Oh no! It's the Blasted Tower!");
            for (int dummy = 0; dummy < Program.Rng.DieRoll(3); dummy++)
            {
                SaveGame.ActivateHiSummon();
            }
        }
        else if (die < 14)
        {
            SaveGame.MsgPrint("Oh no! It's the Devil!");
            SaveGame.Level.SummonSpecific(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty, new DemonMonsterSelector());
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
            SaveGame.Player.TryDecreasingAbilityScore(Ability.Intelligence);
            SaveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
        }
        else if (die < 30)
        {
            SaveGame.MsgPrint("It's a picture of a strange monster.");

            if (!SaveGame.Level.SummonSpecific(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty * 3 / 2, MonsterSelector.RandomBizarre()))
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
            WildMagic(SaveGame, Program.Rng.DieRoll(32) - 1);
        }
        else if (die < 40)
        {
            SaveGame.MsgPrint("It's a teleport card.");
            SaveGame.TeleportPlayer(10);
        }
        else if (die < 42)
        {
            SaveGame.MsgPrint("It's the Star.");
            SaveGame.Player.TimedBlessing.AddTimer(SaveGame.Player.ExperienceLevel);
        }
        else if (die < 47)
        {
            SaveGame.MsgPrint("It's a teleport card.");
            SaveGame.TeleportPlayer(100);
        }
        else if (die < 52)
        {
            SaveGame.MsgPrint("It's a teleport card.");
            SaveGame.TeleportPlayer(200);
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
            SaveGame.Earthquake(SaveGame.Player.MapY, SaveGame.Player.MapX, 5);
        }
        else if (die < 82)
        {
            SaveGame.MsgPrint("It's a picture of a friendly monster.");
            if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty * 3 / 2, new Bizarre1MonsterSelector(), false))
            {
                noneCame = true;
            }
        }
        else if (die < 84)
        {
            SaveGame.MsgPrint("It's a picture of a friendly monster.");
            if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty * 3 / 2, new Bizarre2MonsterSelector(), false))
            {
                noneCame = true;
            }
        }
        else if (die < 86)
        {
            SaveGame.MsgPrint("It's a picture of a friendly monster.");
            if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty * 3 / 2, new Bizarre4MonsterSelector(), false))
            {
                noneCame = true;
            }
        }
        else if (die < 88)
        {
            SaveGame.MsgPrint("It's a picture of a friendly monster.");
            if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty * 3 / 2, new Bizarre5MonsterSelector(), false))
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
            SaveGame.CharmMonster(dir, Math.Min(SaveGame.Player.ExperienceLevel, 20));
        }
        else if (die < 101)
        {
            SaveGame.MsgPrint("It's the Hermit.");
            SaveGame.WallStone();
        }
        else if (die < 111)
        {
            SaveGame.MsgPrint("It's the Judgement.");
            SaveGame.Player.RerollHitPoints();
            if (SaveGame.Player.Dna.HasMutations)
            {
                SaveGame.MsgPrint("You are cured of all mutations.");
                SaveGame.Player.Dna.LoseAllMutations();
                SaveGame.UpdateBonusesFlaggedAction.Set();
                SaveGame.HandleStuff();
            }
        }
        else if (die < 120)
        {
            SaveGame.MsgPrint("It's the Sun.");
            SaveGame.Level.WizLight();
        }
        else
        {
            SaveGame.MsgPrint("It's the World.");
            if (SaveGame.Player.ExperiencePoints < Constants.PyMaxExp)
            {
                int ee = (SaveGame.Player.ExperiencePoints / 25) + 1;
                if (ee > 5000)
                {
                    ee = 5000;
                }
                SaveGame.MsgPrint("You feel more experienced.");
                SaveGame.Player.GainExperience(ee);
            }
        }
        if (noneCame)
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }

    public override string Name => "Tarot Draw";
    
    protected override string? Info()
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
                SaveGame.TeleportPlayer(10);
                break;

            case 4:
            case 5:
            case 6:
                SaveGame.TeleportPlayer(100);
                break;

            case 7:
            case 8:
                SaveGame.TeleportPlayer(200);
                break;

            case 9:
            case 10:
            case 11:
                SaveGame.UnlightArea(10, 3);
                break;

            case 12:
            case 13:
            case 14:
                SaveGame.LightArea(Program.Rng.DiceRoll(2, 3), 2);
                break;

            case 15:
                SaveGame.DestroyDoorsTouch();
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
                SaveGame.DoorCreation();
                break;

            case 23:
            case 24:
            case 25:
                SaveGame.AggravateMonsters();
                break;

            case 26:
                SaveGame.Earthquake(SaveGame.Player.MapY, SaveGame.Player.MapX, 5);
                break;

            case 27:
            case 28:
                SaveGame.Player.Dna.GainMutation();
                break;

            case 29:
            case 30:
                SaveGame.ApplyDisenchant();
                break;

            case 31:
                SaveGame.LoseAllInfo();
                break;

            case 32:
                SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ChaosProjectile>(), 0, spell + 5, 1 + (spell / 10));
                break;

            case 33:
                SaveGame.WallStone();
                break;

            case 34:
            case 35:
                int counter = 0;
                while (counter++ < 8)
                {
                    SaveGame.Level.SummonSpecific(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty * 3 / 2, MonsterSelector.RandomBizarre());
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