// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.Enumerations;
using Cthangband.Projection;
using Cthangband.StaticData;
using System;

namespace Cthangband.Patrons
{
    [Serializable]
    internal abstract class Patron
    {
        public string LongName;
        public bool MultiRew;

        protected int PreferredAbility;
        protected Reward[] Rewards;
        protected string ShortName;

        public static Patron[] NewPatronList()
        {
            Patron[] list = new Patron[]
            {
                new PatronEihort(), new PatronGlaaki(), new PatronYogSothoth(), new PatronYig(),
                new PatronAzathoth(), new PatronRhanTegoth(), new PatronNyarlathotep(), new PatronTsathoggua(),
                new PatronNyogtha(), new PatronIod(), new PatronHastur(), new PatronAbhoth(), new PatronUbboSathla(),
                new PatronCthulhu(), new PatronShubNiggurath(), new PatronCyaegha()
            };
            foreach (Patron patron in list)
            {
                patron.Initialise();
            }
            return list;
        }

        public void GetReward(SaveGame saveGame)
        {
            int type;
            int dummy;
            int nastyChance = 6;
            if (MultiRew)
            {
                return;
            }
            MultiRew = true;
            if (saveGame.Player.Level == 13)
            {
                nastyChance = 2;
            }
            else if (saveGame.Player.Level % 13 == 0)
            {
                nastyChance = 3;
            }
            else if (saveGame.Player.Level % 14 == 0)
            {
                nastyChance = 12;
            }
            if (Program.Rng.DieRoll(nastyChance) == 1)
            {
                type = Program.Rng.DieRoll(20);
            }
            else
            {
                type = Program.Rng.DieRoll(15) + 5;
            }
            if (type < 1)
            {
                type = 1;
            }
            if (type > 20)
            {
                type = 20;
            }
            type--;
            string wrathReason = $"the Wrath of {ShortName}";
            Reward effect = Rewards[type];
            if (Program.Rng.DieRoll(6) == 1)
            {
                SaveGame.Instance.MsgPrint($"{ShortName} rewards you with a mutation!");
                saveGame.Player.Dna.GainMutation(saveGame);
                return;
            }
            switch (effect)
            {
                case Reward.PolySlf:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Thou needst a new form, mortal!'");
                    saveGame.Player.PolymorphSelf(saveGame);
                    break;

                case Reward.GainExp:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Well done, mortal! Lead on!'");
                    if (saveGame.Player.ExperiencePoints < Constants.PyMaxExp)
                    {
                        int ee = (saveGame.Player.ExperiencePoints / 2) + 10;
                        if (ee > 100000)
                        {
                            ee = 100000;
                        }
                        SaveGame.Instance.MsgPrint("You feel more experienced.");
                        saveGame.Player.GainExperience(ee);
                    }
                    break;

                case Reward.LoseExp:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Thou didst not deserve that, slave.'");
                    saveGame.Player.LoseExperience(saveGame.Player.ExperiencePoints / 6);
                    break;

                case Reward.GoodObj:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} whispers:");
                    SaveGame.Instance.MsgPrint("'Use my gift wisely.'");
                    saveGame.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, 1, false);
                    break;

                case Reward.GreaObj:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Use my gift wisely.'");
                    saveGame.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, 1, true);
                    break;

                case Reward.ChaosWp:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Thy deed hath earned thee a worthy blade.'");
                    Item qPtr = new Item(saveGame);
                    int dummy2;
                    switch (Program.Rng.DieRoll(saveGame.Player.Level))
                    {
                        case 1:
                        case 2:
                        case 0:
                            dummy2 = SwordType.SvDagger;
                            break;

                        case 3:
                        case 4:
                            dummy2 = SwordType.SvMainGauche;
                            break;

                        case 5:
                        case 6:
                            dummy2 = SwordType.SvRapier;
                            break;

                        case 7:
                        case 8:
                            dummy2 = SwordType.SvSmallSword;
                            break;

                        case 9:
                        case 10:
                            dummy2 = SwordType.SvShortSword;
                            break;

                        case 11:
                        case 12:
                        case 13:
                            dummy2 = SwordType.SvSabre;
                            break;

                        case 14:
                        case 15:
                        case 16:
                            dummy2 = SwordType.SvCutlass;
                            break;

                        case 17:
                            dummy2 = SwordType.SvTulwar;
                            break;

                        case 18:
                        case 19:
                        case 20:
                            dummy2 = SwordType.SvBroadSword;
                            break;

                        case 21:
                        case 22:
                        case 23:
                            dummy2 = SwordType.SvLongSword;
                            break;

                        case 24:
                        case 25:
                        case 26:
                            dummy2 = SwordType.SvScimitar;
                            break;

                        case 27:
                            dummy2 = SwordType.SvKatana;
                            break;

                        case 28:
                        case 29:
                            dummy2 = SwordType.SvBastardSword;
                            break;

                        case 30:
                        case 31:
                            dummy2 = SwordType.SvTwoHandedSword;
                            break;

                        case 32:
                            dummy2 = SwordType.SvExecutionersSword;
                            break;

                        default:
                            dummy2 = SwordType.SvBladeOfChaos;
                            break;
                    }
                    qPtr.AssignItemType(SaveGame.Instance.ItemTypes.LookupKind(ItemCategory.Sword, dummy2));
                    qPtr.BonusToHit = 3 + (Program.Rng.DieRoll(saveGame.Difficulty) % 10);
                    qPtr.BonusDamage = 3 + (Program.Rng.DieRoll(saveGame.Difficulty) % 10);
                    qPtr.ApplyRandomResistance(Program.Rng.DieRoll(34) + 4);
                    qPtr.RareItemTypeIndex = Enumerations.RareItemType.WeaponChaotic;
                    saveGame.Level.DropNear(qPtr, -1, saveGame.Player.MapY, saveGame.Player.MapX);
                    break;

                case Reward.GoodObs:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Thy deed hath earned thee a worthy reward.'");
                    saveGame.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, Program.Rng.DieRoll(2) + 1, false);
                    break;

                case Reward.GreaObs:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Behold, mortal, how generously I reward thy loyalty.'");
                    saveGame.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, Program.Rng.DieRoll(2) + 1, true);
                    break;

                case Reward.DreadCurse:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} thunders:");
                    SaveGame.Instance.MsgPrint("'Thou art growing arrogant, mortal.'");
                    saveGame.ActivateDreadCurse();
                    break;

                case Reward.SummonM:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'My pets, destroy the arrogant mortal!'");
                    for (dummy = 0; dummy < Program.Rng.DieRoll(5) + 1; dummy++)
                    {
                        saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, 0);
                    }
                    break;

                case Reward.HSummon:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Thou needst worthier opponents!'");
                    saveGame.ActivateHiSummon();
                    break;

                case Reward.DoHavoc:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} whispers out:");
                    SaveGame.Instance.MsgPrint("'Death and destruction! This pleaseth me!'");
                    saveGame.CallChaos();
                    break;

                case Reward.GainAbl:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} rings out:");
                    SaveGame.Instance.MsgPrint("'Stay, mortal, and let me mould thee.'");
                    if (Program.Rng.DieRoll(3) == 1 && !(PreferredAbility < 0))
                    {
                        saveGame.Player.TryIncreasingAbilityScore(PreferredAbility);
                    }
                    else
                    {
                        saveGame.Player.TryIncreasingAbilityScore(Program.Rng.DieRoll(6) - 1);
                    }
                    break;

                case Reward.LoseAbl:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'I grow tired of thee, mortal.'");
                    if (Program.Rng.DieRoll(3) == 1 && !(PreferredAbility < 0))
                    {
                        saveGame.Player.TryDecreasingAbilityScore(PreferredAbility);
                    }
                    else
                    {
                        saveGame.Player.TryDecreasingAbilityScore(Program.Rng.DieRoll(6) - 1);
                    }
                    break;

                case Reward.RuinAbl:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} thunders:");
                    SaveGame.Instance.MsgPrint("'Thou needst a lesson in humility, mortal!'");
                    SaveGame.Instance.MsgPrint("You feel less powerful!");
                    for (dummy = 0; dummy < 6; dummy++)
                    {
                        saveGame.Player.DecreaseAbilityScore(dummy, 10 + Program.Rng.DieRoll(15), true);
                    }
                    break;

                case Reward.PolyWnd:
                    SaveGame.Instance.MsgPrint($"You feel the power of {ShortName} touch you.");
                    saveGame.Player.PolymorphWounds();
                    break;

                case Reward.AugmAbl:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Receive this modest gift from me!'");
                    for (dummy = 0; dummy < 6; dummy++)
                    {
                        saveGame.Player.TryIncreasingAbilityScore(dummy);
                    }
                    break;

                case Reward.HurtLot:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Suffer, pathetic fool!'");
                    saveGame.FireBall(new ProjectDisintegrate(saveGame), 0, saveGame.Player.Level * 4, 4);
                    saveGame.Player.TakeHit(saveGame.Player.Level * 4, wrathReason);
                    break;

                case Reward.HealFul:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Rise, my servant!'");
                    saveGame.Player.RestoreLevel();
                    saveGame.Player.SetTimedPoison(0);
                    saveGame.Player.SetTimedBlindness(0);
                    saveGame.Player.SetTimedConfusion(0);
                    saveGame.Player.SetTimedHallucinations(0);
                    saveGame.Player.SetTimedStun(0);
                    saveGame.Player.SetTimedBleeding(0);
                    saveGame.Player.RestoreHealth(5000);
                    for (dummy = 0; dummy < 6; dummy++)
                    {
                        saveGame.Player.TryRestoringAbilityScore(dummy);
                    }
                    break;

                case Reward.CurseWp:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Thou reliest too much on thine weapon.'");
                    saveGame.CurseWeapon();
                    break;

                case Reward.CurseAr:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Thou reliest too much on thine equipment.'");
                    saveGame.CurseArmour();
                    break;

                case Reward.PissOff:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} whispers:");
                    SaveGame.Instance.MsgPrint("'Now thou shalt pay for annoying me.'");
                    switch (Program.Rng.DieRoll(4))
                    {
                        case 1:
                            saveGame.ActivateDreadCurse();
                            break;

                        case 2:
                            saveGame.ActivateHiSummon();
                            break;

                        case 3:
                            if (Program.Rng.DieRoll(2) == 1)
                            {
                                saveGame.CurseWeapon();
                            }
                            else
                            {
                                saveGame.CurseArmour();
                            }
                            break;

                        default:
                            for (dummy = 0; dummy < 6; dummy++)
                            {
                                saveGame.Player.DecreaseAbilityScore(dummy, 10 + Program.Rng.DieRoll(15), true);
                            }
                            break;
                    }
                    break;

                case Reward.Wrath:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} thunders:");
                    SaveGame.Instance.MsgPrint("'Die, mortal!'");
                    saveGame.Player.TakeHit(saveGame.Player.Level * 4, wrathReason);
                    for (dummy = 0; dummy < 6; dummy++)
                    {
                        saveGame.Player.DecreaseAbilityScore(dummy, 10 + Program.Rng.DieRoll(15), false);
                    }
                    saveGame.ActivateHiSummon();
                    saveGame.ActivateDreadCurse();
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        saveGame.CurseWeapon();
                    }
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        saveGame.CurseArmour();
                    }
                    break;

                case Reward.Destruct:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Death and destruction! This pleaseth me!'");
                    saveGame.DestroyArea(saveGame.Player.MapY, saveGame.Player.MapX, 25);
                    break;

                case Reward.Carnage:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} booms out:");
                    SaveGame.Instance.MsgPrint("'Let me relieve thee of thine oppressors!'");
                    saveGame.Carnage(false);
                    break;

                case Reward.MassGen:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} rings out:");
                    SaveGame.Instance.MsgPrint("'Let me relieve thee of thine oppressors!'");
                    saveGame.MassCarnage(false);
                    break;

                case Reward.DispelC:
                    SaveGame.Instance.MsgPrint($"You can feel the power of {ShortName} assault your enemies!");
                    saveGame.DispelMonsters(saveGame.Player.Level * 4);
                    break;

                case Reward.Ignore:
                    SaveGame.Instance.MsgPrint($"{ShortName} ignores you.");
                    break;

                case Reward.SerDemo:
                    SaveGame.Instance.MsgPrint($"{ShortName} rewards you with a demonic servant!");
                    if (!saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty,
                        Constants.SummonDemon, false))
                    {
                        SaveGame.Instance.MsgPrint("Nobody ever turns up...");
                    }
                    break;

                case Reward.SerMons:
                    SaveGame.Instance.MsgPrint($"{ShortName} rewards you with a servant!");
                    if (!saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty,
                        Constants.SummonNoUniques, false))
                    {
                        SaveGame.Instance.MsgPrint("Nobody ever turns up...");
                    }
                    break;

                case Reward.SerUnde:
                    SaveGame.Instance.MsgPrint($"{ShortName} rewards you with an undead servant!");
                    if (!saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty,
                        Constants.SummonUndead, false))
                    {
                        SaveGame.Instance.MsgPrint("Nobody ever turns up...");
                    }
                    break;

                default:
                    SaveGame.Instance.MsgPrint($"The voice of {ShortName} stammers:");
                    SaveGame.Instance.MsgPrint($"'Uh... uh... the answer's {type}/{effect}, what's the question?'");
                    break;
            }
        }

        public override string ToString()
        {
            return ShortName;
        }

        protected abstract void Initialise();
    }
}