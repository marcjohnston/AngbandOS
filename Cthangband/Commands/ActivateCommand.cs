using Cthangband.Enumerations;
using Cthangband.Projection;
using Cthangband.StaticData;
using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Activate an artifact or similar
    /// </summary>
    /// <param name="itemIndex">
    /// The inventory index of the item to be activated, or -999 to select item
    /// </param>
    [Serializable]
    internal class ActivateCommand : ICommand
    {
        public char Key => 'A';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;
            int dir;
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
            if (itemIndex == -999)
            {
                // No item passed in, so get one; filtering to activatable items only
                saveGame.ItemFilter = saveGame.ItemFilterActivatable;
                if (!saveGame.GetItem(out itemIndex, "Activate which item? ", true, false, false))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have nothing to activate.");
                    }
                    return;
                }
            }
            // Get the item from the index
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Check if the item is activatable
            saveGame.ItemFilter = saveGame.ItemFilterActivatable;
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item))
            {
                SaveGame.Instance.MsgPrint("You can't activate that!");
                saveGame.ItemFilter = null;
                return;
            }
            saveGame.ItemFilter = null;
            // Activating an item uses 100 energy
            saveGame.EnergyUse = 100;
            // Get the level of the item
            int itemLevel = item.ItemType.Level;
            if (item.IsFixedArtifact())
            {
                itemLevel = SaveGame.Instance.FixedArtifacts[item.FixedArtifactIndex].Level;
            }
            // Work out the chance of using the item successfully based on its level and the
            // player's skill
            int chance = saveGame.Player.SkillUseDevice;
            if (saveGame.Player.TimedConfusion != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // Always give a slight chance of success
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            // If we fail our use item roll just tell us and quit
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                saveGame.MsgPrint("You failed to activate it properly.");
                return;
            }
            // If the item is still recharging, then just tell us and quit
            if (item.RechargeTimeLeft != 0)
            {
                saveGame.MsgPrint("It whines, glows and fades...");
                return;
            }
            // We passed the checks, so the item is activated
            saveGame.MsgPrint("You activate it...");
            Gui.PlaySound(SoundEffect.ActivateArtifact);
            // If it is a random artifact then use its ability and quit
            if (string.IsNullOrEmpty(item.RandartName) == false)
            {
                SaveGame.Instance.ActivateRandomArtifact(item);
                return;
            }
            // If it's a fixed artifact then use its ability
            if (item.FixedArtifactIndex != 0)
            {
                switch (item.FixedArtifactIndex)
                {
                    // Star Essence of Polaris lights the area
                    case FixedArtifactId.StarEssenceOfPolaris:
                        {
                            SaveGame.Instance.MsgPrint("The essence wells with clear light...");
                            SaveGame.Instance.LightArea(Program.Rng.DiceRoll(2, 15), 3);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(10) + 10;
                            break;
                        }
                    // Star essence of Xoth lights and maps the area
                    case FixedArtifactId.StarEssenceOfXoth:
                        {
                            SaveGame.Instance.MsgPrint("The essence shines brightly...");
                            saveGame.Level.MapArea();
                            SaveGame.Instance.LightArea(Program.Rng.DiceRoll(2, 15), 3);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
                            break;
                        }
                    // Shining Trapezohedron lights the entire level and recalls us, but drains
                    // health to do so
                    case FixedArtifactId.ShiningTrapezohedron:
                        {
                            SaveGame.Instance.MsgPrint("The gemstone flashes bright red!");
                            saveGame.Level.WizLight();
                            SaveGame.Instance.MsgPrint("The gemstone drains your vitality...");
                            saveGame.Player.TakeHit(Program.Rng.DiceRoll(3, 8), "the Gemstone 'Trapezohedron'");
                            SaveGame.Instance.DetectTraps();
                            SaveGame.Instance.DetectDoors();
                            SaveGame.Instance.DetectStairs();
                            if (Gui.GetCheck("Activate recall? "))
                            {
                                saveGame.Player.ToggleRecall();
                            }
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(20) + 20;
                            break;
                        }
                    // Amulet of Lobon protects us from evil
                    case FixedArtifactId.AmuletOfLobon:
                        {
                            SaveGame.Instance.MsgPrint("The amulet lets out a shrill wail...");
                            int k = 3 * saveGame.Player.Level;
                            saveGame.Player.SetTimedProtectionFromEvil(saveGame.Player.TimedProtectionFromEvil + Program.Rng.DieRoll(25) + k);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(225) + 225;
                            break;
                        }
                    // Amulet of Abdul Alhazred dispels evil
                    case FixedArtifactId.AmuletOfAbdulAlhazred:
                        {
                            SaveGame.Instance.MsgPrint("The amulet floods the area with goodness...");
                            SaveGame.Instance.DispelEvil(saveGame.Player.Level * 5);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    // Ring of Magic has a djinn in it that drains life from an opponent
                    case FixedArtifactId.RingOfMagic:
                        {
                            SaveGame.Instance.MsgPrint("You order Frakir to strangle your opponent.");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            if (SaveGame.Instance.DrainLife(dir, 100))
                            {
                                item.RechargeTimeLeft = Program.Rng.RandomLessThan(100) + 100;
                            }
                            break;
                        }
                    // Ring of Bast hastes you
                    case FixedArtifactId.RingOfBast:
                        {
                            SaveGame.Instance.MsgPrint("The ring glows brightly...");
                            if (saveGame.Player.TimedHaste == 0)
                            {
                                saveGame.Player.SetTimedHaste(Program.Rng.DieRoll(75) + 75);
                            }
                            else
                            {
                                saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + 5);
                            }
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(150) + 150;
                            break;
                        }
                    // Ring of Elemental Fire casts a fireball
                    case FixedArtifactId.RingOfElementalPowerFire:
                        {
                            SaveGame.Instance.MsgPrint("The ring glows deep red...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBall(new ProjectFire(), dir, 120, 3);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(225) + 225;
                            break;
                        }
                    // Ring of Elemental Ice casts a coldball
                    case FixedArtifactId.RingOfElementalPowerIce:
                        {
                            SaveGame.Instance.MsgPrint("The ring glows bright white...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBall(new ProjectCold(), dir, 200, 3);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(325) + 325;
                            break;
                        }
                    // Ring of Elemental Lightning casts a lightning ball
                    case FixedArtifactId.RingOfElementalPowerStorm:
                        {
                            SaveGame.Instance.MsgPrint("The ring glows deep blue...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBall(new ProjectElec(), dir, 250, 3);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(425) + 425;
                            break;
                        }
                    // Ring of Set has a random effect
                    case FixedArtifactId.RingOfSet:
                        {
                            SaveGame.Instance.MsgPrint("The ring glows intensely black...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.RingOfSetPower(dir);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    // Razorback gives you a point-blank lightning ball
                    case FixedArtifactId.DragonScaleRazorback:
                        {
                            SaveGame.Instance.MsgPrint("Your armor is surrounded by lightning...");
                            for (int i = 0; i < 8; i++)
                            {
                                SaveGame.Instance.FireBall(new ProjectElec(), saveGame.Level.OrderedDirection[i], 150, 3);
                            }
                            item.RechargeTimeLeft = 1000;
                            break;
                        }
                    // Bladeturner heals you and gives you timed resistances
                    case FixedArtifactId.DragonScaleBladeturner:
                        {
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.MsgPrint("You breathe the elements.");
                            SaveGame.Instance.FireBall(new ProjectMissile(), dir, 300, 4);
                            SaveGame.Instance.MsgPrint("Your armor glows many colors...");
                            saveGame.Player.SetTimedFear(0);
                            saveGame.Player.SetTimedSuperheroism(saveGame.Player.TimedSuperheroism + Program.Rng.DieRoll(50) + 50);
                            saveGame.Player.RestoreHealth(30);
                            saveGame.Player.SetTimedBlessing(saveGame.Player.TimedBlessing + Program.Rng.DieRoll(50) + 50);
                            saveGame.Player.SetTimedAcidResistance(saveGame.Player.TimedAcidResistance + Program.Rng.DieRoll(50) + 50);
                            saveGame.Player.SetTimedLightningResistance(saveGame.Player.TimedLightningResistance + Program.Rng.DieRoll(50) + 50);
                            saveGame.Player.SetTimedFireResistance(saveGame.Player.TimedFireResistance + Program.Rng.DieRoll(50) + 50);
                            saveGame.Player.SetTimedColdResistance(saveGame.Player.TimedColdResistance + Program.Rng.DieRoll(50) + 50);
                            saveGame.Player.SetTimedPoisonResistance(saveGame.Player.TimedPoisonResistance + Program.Rng.DieRoll(50) + 50);
                            item.RechargeTimeLeft = 400;
                            break;
                        }
                    // Soulkeeper heals you a lot
                    case FixedArtifactId.PlateMailSoulkeeper:
                        {
                            SaveGame.Instance.MsgPrint("Your armor glows a bright white...");
                            SaveGame.Instance.MsgPrint("You feel much better...");
                            saveGame.Player.RestoreHealth(1000);
                            saveGame.Player.SetTimedBleeding(0);
                            item.RechargeTimeLeft = 888;
                            break;
                        }
                    // Vampire Hunter cures most ailments
                    case FixedArtifactId.ArmourOfTheVampireHunter:
                        {
                            SaveGame.Instance.MsgPrint("A heavenly choir sings...");
                            saveGame.Player.SetTimedPoison(0);
                            saveGame.Player.SetTimedBleeding(0);
                            saveGame.Player.SetTimedStun(0);
                            saveGame.Player.SetTimedConfusion(0);
                            saveGame.Player.SetTimedBlindness(0);
                            saveGame.Player.SetTimedHeroism(saveGame.Player.TimedHeroism + Program.Rng.DieRoll(25) + 25);
                            saveGame.Player.RestoreHealth(777);
                            item.RechargeTimeLeft = 300;
                            break;
                        }
                    // Orc does Carnage
                    case FixedArtifactId.ArmourOfTheOrcs:
                        {
                            SaveGame.Instance.MsgPrint("Your armor glows deep blue...");
                            SaveGame.Instance.Carnage(true);
                            item.RechargeTimeLeft = 500;
                            break;
                        }
                    // Ogre Lords destroys doors
                    case FixedArtifactId.ArmourOfTheOgreLords:
                        {
                            SaveGame.Instance.MsgPrint("Your armor glows bright red...");
                            SaveGame.Instance.DestroyDoorsTouch();
                            item.RechargeTimeLeft = 10;
                            break;
                        }
                    // Dragon Helm and Terror Mask cause fear
                    case FixedArtifactId.DragonHelmOfPower:
                    case FixedArtifactId.HelmTerrorMask:
                        {
                            SaveGame.Instance.TurnMonsters(40 + saveGame.Player.Level);
                            item.RechargeTimeLeft = 3 * (saveGame.Player.Level + 10);
                            break;
                        }
                    // Skull Keeper detects everything
                    case FixedArtifactId.HelmSkullkeeper:
                        {
                            SaveGame.Instance.MsgPrint("Your helm glows bright white...");
                            SaveGame.Instance.MsgPrint("An image forms in your mind...");
                            SaveGame.Instance.DetectAll();
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(55) + 55;
                            break;
                        }
                    // Sun Crown heals
                    case FixedArtifactId.CrownOfTheSun:
                        {
                            SaveGame.Instance.MsgPrint("Your crown glows deep yellow...");
                            SaveGame.Instance.MsgPrint("You feel a warm tingling inside...");
                            saveGame.Player.RestoreHealth(700);
                            saveGame.Player.SetTimedBleeding(0);
                            item.RechargeTimeLeft = 250;
                            break;
                        }
                    // Cloak of Barzai gives resistances
                    case FixedArtifactId.CloakOfBarzai:
                        {
                            SaveGame.Instance.MsgPrint("Your cloak glows many colours...");
                            saveGame.Player.SetTimedAcidResistance(saveGame.Player.TimedAcidResistance + Program.Rng.DieRoll(20) + 20);
                            saveGame.Player.SetTimedLightningResistance(saveGame.Player.TimedLightningResistance + Program.Rng.DieRoll(20) + 20);
                            saveGame.Player.SetTimedFireResistance(saveGame.Player.TimedFireResistance + Program.Rng.DieRoll(20) + 20);
                            saveGame.Player.SetTimedColdResistance(saveGame.Player.TimedColdResistance + Program.Rng.DieRoll(20) + 20);
                            saveGame.Player.SetTimedPoisonResistance(saveGame.Player.TimedPoisonResistance + Program.Rng.DieRoll(20) + 20);
                            item.RechargeTimeLeft = 111;
                            break;
                        }
                    // Darkness sends monsters to sleep
                    case FixedArtifactId.CloakDarkness:
                        {
                            SaveGame.Instance.MsgPrint("Your cloak glows deep blue...");
                            SaveGame.Instance.SleepMonstersTouch();
                            item.RechargeTimeLeft = 55;
                            break;
                        }
                    // Swashbuckler recharges items
                    case FixedArtifactId.CloakOfTheSwashbuckler:
                        {
                            SaveGame.Instance.MsgPrint("Your cloak glows bright yellow...");
                            SaveGame.Instance.Recharge(60);
                            item.RechargeTimeLeft = 70;
                            break;
                        }
                    // Shifter teleports you
                    case FixedArtifactId.CloakShifter:
                        {
                            SaveGame.Instance.MsgPrint("Your cloak twists space around you...");
                            SaveGame.Instance.TeleportPlayer(100);
                            item.RechargeTimeLeft = 45;
                            break;
                        }
                    // Nyogtha restores experience
                    case FixedArtifactId.ShadowCloakOfNyogtha:
                        {
                            SaveGame.Instance.MsgPrint("Your cloak glows a deep red...");
                            saveGame.Player.RestoreLevel();
                            item.RechargeTimeLeft = 450;
                            break;
                        }
                    // Light shoots magic missiles
                    case FixedArtifactId.GlovesOfLight:
                        {
                            SaveGame.Instance.MsgPrint("Your gloves glow extremely brightly...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBolt(new ProjectMissile(), dir,
                                Program.Rng.DiceRoll(2, 6));
                            item.RechargeTimeLeft = 2;
                            break;
                        }
                    // Iron Fist shoots fire bolts
                    case FixedArtifactId.GauntletIronfist:
                        {
                            SaveGame.Instance.MsgPrint("Your gauntlets are covered in fire...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBolt(new ProjectFire(), dir, Program.Rng.DiceRoll(9, 8));
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(8) + 8;
                            break;
                        }
                    // Ghouls shoot cold bolts
                    case FixedArtifactId.GauntletsOfGhouls:
                        {
                            SaveGame.Instance.MsgPrint("Your gauntlets are covered in frost...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBolt(new ProjectCold(), dir, Program.Rng.DiceRoll(6, 8));
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(7) + 7;
                            break;
                        }
                    // White Spark shoot lightning bolts
                    case FixedArtifactId.GauntletsWhiteSpark:
                        {
                            SaveGame.Instance.MsgPrint("Your gauntlets are covered in sparks...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBolt(new ProjectElec(), dir, Program.Rng.DiceRoll(4, 8));
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(6) + 6;
                            break;
                        }
                    // The Dead shoot acid bolts
                    case FixedArtifactId.GauntletsOfTheDead:
                        {
                            SaveGame.Instance.MsgPrint("Your gauntlets are covered in acid...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBolt(new ProjectAcid(), dir, Program.Rng.DiceRoll(5, 8));
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(5) + 5;
                            break;
                        }
                    // Cesti shoot arrows
                    case FixedArtifactId.CestiOfCombat:
                        {
                            SaveGame.Instance.MsgPrint("Your cesti grows magical spikes...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBolt(new ProjectArrow(), dir, 150);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(90) + 90;
                            break;
                        }
                    // Boots haste you
                    case FixedArtifactId.BootsOfIthaqua:
                        {
                            SaveGame.Instance.MsgPrint("A wind swirls around your boots...");
                            if (saveGame.Player.TimedHaste == 0)
                            {
                                saveGame.Player.SetTimedHaste(Program.Rng.DieRoll(20) + 20);
                            }
                            else
                            {
                                saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + 5);
                            }
                            item.RechargeTimeLeft = 200;
                            break;
                        }
                    // Dancing heal poison and fear
                    case FixedArtifactId.BootsOfDancing:
                        {
                            SaveGame.Instance.MsgPrint("Your boots glow deep blue...");
                            saveGame.Player.SetTimedFear(0);
                            saveGame.Player.SetTimedPoison(0);
                            item.RechargeTimeLeft = 5;
                            break;
                        }
                    // Faith shoots a fire bolt
                    case FixedArtifactId.DaggerOfFaith:
                        {
                            SaveGame.Instance.MsgPrint("Your dagger is covered in fire...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBolt(new ProjectFire(), dir, Program.Rng.DiceRoll(9, 8));
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(8) + 8;
                            break;
                        }
                    // Hope shoots a frost bolt
                    case FixedArtifactId.DaggerOfHope:
                        {
                            SaveGame.Instance.MsgPrint("Your dagger is covered in frost...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBolt(new ProjectCold(), dir, Program.Rng.DiceRoll(6, 8));
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(7) + 7;
                            break;
                        }
                    // Charity shoots a lightning bolt
                    case FixedArtifactId.DaggerOfCharity:
                        {
                            SaveGame.Instance.MsgPrint("Your dagger is covered in sparks...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBolt(new ProjectElec(), dir, Program.Rng.DiceRoll(4, 8));
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(6) + 6;
                            break;
                        }
                    // Thoth shoots a poison ball
                    case FixedArtifactId.DaggerOfThoth:
                        {
                            SaveGame.Instance.MsgPrint("Your dagger throbs deep green...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBall(new ProjectPois(), dir, 12, 3);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(4) + 4;
                            break;
                        }
                    // Icicle shoots a cold ball
                    case FixedArtifactId.DaggerIcicle:
                        {
                            SaveGame.Instance.MsgPrint("Your dagger is covered in frost...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBall(new ProjectCold(), dir, 48, 2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(5) + 5;
                            break;
                        }
                    // Karakal teleports you randomly
                    case FixedArtifactId.SwordOfKarakal:
                        {
                            switch (Program.Rng.DieRoll(13))
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                    SaveGame.Instance.TeleportPlayer(10);
                                    break;

                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                case 10:
                                    SaveGame.Instance.TeleportPlayer(222);
                                    break;

                                case 11:
                                case 12:
                                    SaveGame.Instance.StairCreation();
                                    break;

                                default:
                                    if (Gui.GetCheck("Leave this level? "))
                                    {
                                        {
                                            SaveGame.Instance.DoCmdSaveGame(true);
                                        }
                                        SaveGame.Instance.NewLevelFlag = true;
                                        SaveGame.Instance.CameFrom = LevelStart.StartRandom;
                                    }
                                    break;
                            }
                            item.RechargeTimeLeft = 35;
                            break;
                        }
                    // Excalibur shoots a frost ball
                    case FixedArtifactId.SwordExcalibur:
                        {
                            SaveGame.Instance.MsgPrint("Your sword glows an intense blue...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBall(new ProjectCold(), dir, 100, 2);
                            item.RechargeTimeLeft = 300;
                            break;
                        }
                    // Dawn Sword summons a reaver
                    case FixedArtifactId.SwordOfTheDawn:
                        {
                            SaveGame.Instance.MsgPrint("Your sword flickers black for a moment...");
                            saveGame.Level.Monsters.SummonSpecificFriendly(saveGame.Player.MapY, saveGame.Player.MapX, SaveGame.Instance.Difficulty, Constants.SummonReaver, true);
                            item.RechargeTimeLeft = 500 + Program.Rng.DieRoll(500);
                            break;
                        }
                    // Everflame shoots a fire ball
                    case FixedArtifactId.SwordOfEverflame:
                        {
                            SaveGame.Instance.MsgPrint("Your sword glows an intense red...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBall(new ProjectFire(), dir, 72, 2);
                            item.RechargeTimeLeft = 400;
                            break;
                        }
                    // Theoden drains life
                    case FixedArtifactId.AxeOfTheoden:
                        {
                            SaveGame.Instance.MsgPrint("Your axe blade glows black...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.DrainLife(dir, 120);
                            item.RechargeTimeLeft = 400;
                            break;
                        }
                    // Grungnir shoots a lightning ball
                    case FixedArtifactId.SpearGungnir:
                        {
                            SaveGame.Instance.MsgPrint("Your spear crackles with electricity...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBall(new ProjectElec(), dir, 100, 3);
                            item.RechargeTimeLeft = 500;
                            break;
                        }
                    // Destiny does rock to mud
                    case FixedArtifactId.SpearOfDestiny:
                        {
                            SaveGame.Instance.MsgPrint("Your spear pulsates...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.WallToMud(dir);
                            item.RechargeTimeLeft = 5;
                            break;
                        }
                    // Trolls does mass carnage
                    case FixedArtifactId.AxeOfTheTrolls:
                        {
                            SaveGame.Instance.MsgPrint("Your axe lets out a long, shrill note...");
                            SaveGame.Instance.MassCarnage(true);
                            item.RechargeTimeLeft = 1000;
                            break;
                        }
                    // Spleens Slicer heals you
                    case FixedArtifactId.AxeSpleenSlicer:
                        {
                            SaveGame.Instance.MsgPrint("Your battle axe radiates deep purple...");
                            saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(4, 8));
                            saveGame.Player.SetTimedBleeding((saveGame.Player.TimedBleeding / 2) - 50);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(3) + 3;
                            break;
                        }
                    // Gnorri teleports monsters away
                    case FixedArtifactId.TridentOfTheGnorri:
                        {
                            SaveGame.Instance.MsgPrint("Your trident glows deep red...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.TeleportMonster(dir);
                            item.RechargeTimeLeft = 150;
                            break;
                        }
                    // G'Harne does Word of Recall
                    case FixedArtifactId.ScytheOfGharne:
                        {
                            SaveGame.Instance.MsgPrint("Your scythe glows soft white...");
                            saveGame.Player.ToggleRecall();
                            item.RechargeTimeLeft = 200;
                            break;
                        }
                    // Totila does confusion
                    case FixedArtifactId.FlailTotila:
                        {
                            SaveGame.Instance.MsgPrint("Your flail glows in scintillating colours...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.ConfuseMonster(dir, 20);
                            item.RechargeTimeLeft = 15;
                            break;
                        }
                    // Firestarter does fire ball
                    case FixedArtifactId.MorningStarFirestarter:
                        {
                            SaveGame.Instance.MsgPrint("Your morning star rages in fire...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.FireBall(new ProjectFire(), dir, 72, 3);
                            item.RechargeTimeLeft = 100;
                            break;
                        }
                    // Thunder does haste
                    case FixedArtifactId.MaceThunder:
                        {
                            SaveGame.Instance.MsgPrint("Your mace glows bright green...");
                            if (saveGame.Player.TimedHaste == 0)
                            {
                                saveGame.Player.SetTimedHaste(Program.Rng.DieRoll(20) + 20);
                            }
                            else
                            {
                                saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + 5);
                            }
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(100) + 100;
                            break;
                        }
                    // Ereril does identify
                    case FixedArtifactId.QuarterstaffEriril:
                        {
                            SaveGame.Instance.MsgPrint("Your quarterstaff glows yellow...");
                            if (!SaveGame.Instance.IdentifyItem())
                            {
                                return;
                            }
                            item.RechargeTimeLeft = 10;
                            break;
                        }
                    // Atal does full identify
                    case FixedArtifactId.QuarterstaffOfAtal:
                        {
                            SaveGame.Instance.MsgPrint("Your quarterstaff glows brightly...");
                            SaveGame.Instance.DetectAll();
                            SaveGame.Instance.Probing();
                            SaveGame.Instance.IdentifyFully();
                            item.RechargeTimeLeft = 1000;
                            break;
                        }
                    // Justice drains life
                    case FixedArtifactId.HammerJustice:
                        {
                            SaveGame.Instance.MsgPrint("Your hammer glows white...");
                            if (!targetEngine.GetDirectionWithAim(out dir))
                            {
                                return;
                            }
                            SaveGame.Instance.DrainLife(dir, 90);
                            item.RechargeTimeLeft = 70;
                            break;
                        }
                    // Death brands your bolts
                    case FixedArtifactId.CrossbowOfDeath:
                        {
                            SaveGame.Instance.MsgPrint("Your crossbow glows deep red...");
                            SaveGame.Instance.BrandBolts();
                            item.RechargeTimeLeft = 999;
                            break;
                        }
                }
                return;
            }
            // If it wasn't an artifact, then check the other types of activatable item Planar
            // weapon teleports you
            if (item.RareItemTypeIndex == Enumerations.RareItemType.WeaponPlanarWeapon)
            {
                SaveGame.Instance.TeleportPlayer(100);
                item.RechargeTimeLeft = 50 + Program.Rng.DieRoll(50);
                return;
            }
            // Dragon armour gives you a ball of the relevant damage type
            if (item.Category == ItemCategory.DragArmor)
            {
                if (!targetEngine.GetDirectionWithAim(out dir))
                {
                    return;
                }
                switch (item.ItemSubCategory)
                {
                    case DragonArmour.SvDragonBlue:
                        {
                            SaveGame.Instance.MsgPrint("You breathe lightning.");
                            SaveGame.Instance.FireBall(new ProjectElec(), dir, 100, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonWhite:
                        {
                            SaveGame.Instance.MsgPrint("You breathe frost.");
                            SaveGame.Instance.FireBall(new ProjectCold(), dir, 110, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonBlack:
                        {
                            SaveGame.Instance.MsgPrint("You breathe acid.");
                            SaveGame.Instance.FireBall(new ProjectAcid(), dir, 130, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonGreen:
                        {
                            SaveGame.Instance.MsgPrint("You breathe poison gas.");
                            SaveGame.Instance.FireBall(new ProjectPois(), dir, 150, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonRed:
                        {
                            SaveGame.Instance.MsgPrint("You breathe fire.");
                            SaveGame.Instance.FireBall(new ProjectFire(), dir, 200, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonMultihued:
                        {
                            chance = Program.Rng.RandomLessThan(5);
                            string element = chance == 1
                                ? "lightning"
                                : (chance == 2 ? "frost" : (chance == 3 ? "acid" : (chance == 4 ? "poison gas" : "fire")));
                            SaveGame.Instance.MsgPrint($"You breathe {element}.");
                            switch (chance)
                            {
                                case 0:
                                    SaveGame.Instance.FireBall(new ProjectFire(),
                                        dir, 250, -2);
                                    break;

                                case 1:
                                    SaveGame.Instance.FireBall(new ProjectElec(),
                                        dir, 250, -2);
                                    break;

                                case 2:
                                    SaveGame.Instance.FireBall(new ProjectCold(),
                                        dir, 250, -2);
                                    break;

                                case 3:
                                    SaveGame.Instance.FireBall(new ProjectAcid(),
                                        dir, 250, -2);
                                    break;

                                case 4:
                                    SaveGame.Instance.FireBall(new ProjectPois(),
                                        dir, 250, -2);
                                    break;
                            }
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(225) + 225;
                            break;
                        }
                    case DragonArmour.SvDragonBronze:
                        {
                            SaveGame.Instance.MsgPrint("You breathe confusion.");
                            SaveGame.Instance.FireBall(new ProjectConfusion(), dir, 120, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonGold:
                        {
                            SaveGame.Instance.MsgPrint("You breathe sound.");
                            SaveGame.Instance.FireBall(new ProjectSound(), dir, 130, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonChaos:
                        {
                            chance = Program.Rng.RandomLessThan(2);
                            string element = chance == 1 ? "chaos" : "disenchantment";
                            SaveGame.Instance.MsgPrint($"You breathe {element}.");
                            SaveGame.Instance.FireBall(
                                projectile: chance == 1 ? (Projectile)new ProjectChaos() : new ProjectDisenchant(), dir: dir, dam: 220, rad: -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonLaw:
                        {
                            chance = Program.Rng.RandomLessThan(2);
                            string element = chance == 1 ? "sound" : "shards";
                            SaveGame.Instance.MsgPrint($"You breathe {element}.");
                            SaveGame.Instance.FireBall(
                                chance == 1 ? (Projectile)new ProjectSound() : new ProjectExplode(), dir, 230, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonBalance:
                        {
                            chance = Program.Rng.RandomLessThan(4);
                            string element = chance == 1
                                ? "chaos"
                                : (chance == 2 ? "disenchantment" : (chance == 3 ? "sound" : "shards"));
                            SaveGame.Instance.MsgPrint($"You breathe {element}.");
                            SaveGame.Instance.FireBall(
                                chance == 1
                                    ? new ProjectChaos()
                                    : (chance == 2
                                        ? new ProjectDisenchant()
                                        : (chance == 3 ? (Projectile)new ProjectSound() : new ProjectExplode())), dir, 250, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonShining:
                        {
                            chance = Program.Rng.RandomLessThan(2);
                            string element = chance == 0 ? "light" : "darkness";
                            SaveGame.Instance.MsgPrint($"You breathe {element}.");
                            SaveGame.Instance.FireBall(
                                chance == 0 ? (Projectile)new ProjectLight() : new ProjectDark(), dir, 200, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonPower:
                        {
                            SaveGame.Instance.MsgPrint("You breathe the elements.");
                            SaveGame.Instance.FireBall(new ProjectMissile(), dir, 300, -3);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                }
                return;
            }
            // Elemental rings give you a ball of the appropriate element
            if (item.Category == ItemCategory.Ring)
            {
                if (!targetEngine.GetDirectionWithAim(out dir))
                {
                    return;
                }
                switch (item.ItemSubCategory)
                {
                    case RingType.Acid:
                        {
                            SaveGame.Instance.FireBall(new ProjectAcid(), dir, 50, 2);
                            saveGame.Player.SetTimedAcidResistance(saveGame.Player.TimedAcidResistance + Program.Rng.DieRoll(20) + 20);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
                            break;
                        }
                    case RingType.Ice:
                        {
                            SaveGame.Instance.FireBall(new ProjectCold(), dir, 50, 2);
                            saveGame.Player.SetTimedColdResistance(saveGame.Player.TimedColdResistance + Program.Rng.DieRoll(20) + 20);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
                            break;
                        }
                    case RingType.Flames:
                        {
                            SaveGame.Instance.FireBall(new ProjectFire(), dir, 50, 2);
                            saveGame.Player.SetTimedFireResistance(saveGame.Player.TimedFireResistance + Program.Rng.DieRoll(20) + 20);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
                            break;
                        }
                }
                return;
            }
            // We ran out of item types
            SaveGame.Instance.MsgPrint("Oops. That object cannot be activated.");
        }
    }
}
