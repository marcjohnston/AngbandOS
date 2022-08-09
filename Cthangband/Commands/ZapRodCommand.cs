using Cthangband.Enumerations;
using Cthangband.Projection;
using Cthangband.StaticData;
using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Use a rod from the inventory or ground
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the item to be used </param>
    [Serializable]
    internal class ZapRodCommand : ICommand
    {
        public char Key => 'z';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;

            // Get the item if we weren't passed it
            Inventory.ItemFilterCategory = ItemCategory.Rod;
            if (itemIndex == -999)
            {
                if (!saveGame.GetItem(out itemIndex, "Zap which rod? ", false, true, true))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have no rod to zap.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Make sure the item is actually a rod
            Inventory.ItemFilterCategory = ItemCategory.Rod;
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item))
            {
                saveGame.MsgPrint("That is not a rod!");
                Inventory.ItemFilterCategory = 0;
                return;
            }
            Inventory.ItemFilterCategory = 0;
            // Rods can't be used from the floor
            if (itemIndex < 0 && item.Count > 1)
            {
                saveGame.MsgPrint("You must first pick up the rods.");
                return;
            }
            // We may need to aim the rod
            int dir = 5;
            if ((item.ItemSubCategory >= RodType.MinimumAimed && item.ItemSubCategory != RodType.Havoc) ||
                !item.IsFlavourAware())
            {
                TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
                if (!targetEngine.GetDirectionWithAim(out dir))
                {
                    return;
                }
            }
            // Using a rod takes a whole turn
            saveGame.EnergyUse = 100;
            bool identified = false;
            int itemLevel = item.ItemType.Level;
            // Chance to successfully use it is skill (halved if confused) - rod level (capped at 50)
            int chance = saveGame.Player.SkillUseDevice;
            if (saveGame.Player.TimedConfusion != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // There's always a small chance of success
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            // Do the actual check
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                saveGame.MsgPrint("You failed to use the rod properly.");
                return;
            }
            // Rods only have a single charge but recharge over time
            if (item.TypeSpecificValue != 0)
            {
                saveGame.MsgPrint("The rod is still charging.");
                return;
            }
            Gui.PlaySound(SoundEffect.ZapRod);
            // Do the rod-specific effect
            bool useCharge = true;
            switch (item.ItemSubCategory)
            {
                case RodType.DetectTrap:
                    {
                        if (saveGame.DetectTraps())
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 10 + Program.Rng.DieRoll(10);
                        break;
                    }
                case RodType.DetectDoor:
                    {
                        if (saveGame.DetectDoors())
                        {
                            identified = true;
                        }
                        if (saveGame.DetectStairs())
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 70;
                        break;
                    }
                case RodType.Identify:
                    {
                        identified = true;
                        if (!saveGame.IdentifyItem())
                        {
                            useCharge = false;
                        }
                        item.TypeSpecificValue = 10;
                        break;
                    }
                case RodType.Recall:
                    {
                        saveGame.Player.ToggleRecall();
                        identified = true;
                        item.TypeSpecificValue = 60;
                        break;
                    }
                case RodType.Illumination:
                    {
                        if (saveGame.LightArea(Program.Rng.DiceRoll(2, 8), 2))
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 10 + Program.Rng.DieRoll(11);
                        break;
                    }
                case RodType.Mapping:
                    {
                        saveGame.Level.MapArea();
                        identified = true;
                        item.TypeSpecificValue = 99;
                        break;
                    }
                case RodType.Detection:
                    {
                        saveGame.DetectAll();
                        identified = true;
                        item.TypeSpecificValue = 99;
                        break;
                    }
                case RodType.Probing:
                    {
                        saveGame.Probing();
                        identified = true;
                        item.TypeSpecificValue = 50;
                        break;
                    }
                case RodType.Curing:
                    {
                        if (saveGame.Player.SetTimedBlindness(0))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.SetTimedPoison(0))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.SetTimedConfusion(0))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.SetTimedStun(0))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.SetTimedBleeding(0))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.SetTimedHallucinations(0))
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 999;
                        break;
                    }
                case RodType.Healing:
                    {
                        if (saveGame.Player.RestoreHealth(500))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.SetTimedStun(0))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.SetTimedBleeding(0))
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 999;
                        break;
                    }
                case RodType.Restoration:
                    {
                        if (saveGame.Player.RestoreLevel())
                        {
                            identified = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Strength))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Intelligence))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Wisdom))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Dexterity))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Constitution))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Charisma))
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 999;
                        break;
                    }
                case RodType.Speed:
                    {
                        if (saveGame.Player.TimedHaste == 0)
                        {
                            if (saveGame.Player.SetTimedHaste(Program.Rng.DieRoll(30) + 15))
                            {
                                identified = true;
                            }
                        }
                        else
                        {
                            saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + 5);
                        }
                        item.TypeSpecificValue = 99;
                        break;
                    }
                case RodType.TeleportAway:
                    {
                        if (saveGame.TeleportMonster(dir))
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 25;
                        break;
                    }
                case RodType.Disarming:
                    {
                        if (saveGame.DisarmTrap(dir))
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 15 + Program.Rng.DieRoll(15);
                        break;
                    }
                case RodType.Light:
                    {
                        saveGame.MsgPrint("A line of blue shimmering light appears.");
                        saveGame.LightLine(dir);
                        identified = true;
                        item.TypeSpecificValue = 9;
                        break;
                    }
                case RodType.SleepMonster:
                    {
                        if (saveGame.SleepMonster(dir))
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 18;
                        break;
                    }
                case RodType.SlowMonster:
                    {
                        if (saveGame.SlowMonster(dir))
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 20;
                        break;
                    }
                case RodType.DrainLife:
                    {
                        if (saveGame.DrainLife(dir, 75))
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 23;
                        break;
                    }
                case RodType.Polymorph:
                    {
                        if (saveGame.PolyMonster(dir))
                        {
                            identified = true;
                        }
                        item.TypeSpecificValue = 25;
                        break;
                    }
                case RodType.AcidBolt:
                    {
                        saveGame.FireBoltOrBeam(10, new ProjectAcid(), dir,
                            Program.Rng.DiceRoll(6, 8));
                        identified = true;
                        item.TypeSpecificValue = 12;
                        break;
                    }
                case RodType.ElecBolt:
                    {
                        saveGame.FireBoltOrBeam(10, new ProjectElec(), dir,
                            Program.Rng.DiceRoll(3, 8));
                        identified = true;
                        item.TypeSpecificValue = 11;
                        break;
                    }
                case RodType.FireBolt:
                    {
                        saveGame.FireBoltOrBeam(10, new ProjectFire(), dir,
                            Program.Rng.DiceRoll(8, 8));
                        identified = true;
                        item.TypeSpecificValue = 15;
                        break;
                    }
                case RodType.ColdBolt:
                    {
                        saveGame.FireBoltOrBeam(10, new ProjectCold(), dir,
                            Program.Rng.DiceRoll(5, 8));
                        identified = true;
                        item.TypeSpecificValue = 13;
                        break;
                    }
                case RodType.AcidBall:
                    {
                        saveGame.FireBall(new ProjectAcid(), dir, 60, 2);
                        identified = true;
                        item.TypeSpecificValue = 27;
                        break;
                    }
                case RodType.ElecBall:
                    {
                        saveGame.FireBall(new ProjectElec(), dir, 32, 2);
                        identified = true;
                        item.TypeSpecificValue = 23;
                        break;
                    }
                case RodType.FireBall:
                    {
                        saveGame.FireBall(new ProjectFire(), dir, 72, 2);
                        identified = true;
                        item.TypeSpecificValue = 30;
                        break;
                    }
                case RodType.ColdBall:
                    {
                        saveGame.FireBall(new ProjectCold(), dir, 48, 2);
                        identified = true;
                        item.TypeSpecificValue = 25;
                        break;
                    }
                case RodType.Havoc:
                    {
                        saveGame.CallChaos();
                        identified = true;
                        item.TypeSpecificValue = 250;
                        break;
                    }
            }
            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // We may have just discovered what the rod does
            item.ObjectTried();
            if (identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            // We may not have actually used a charge
            if (!useCharge)
            {
                item.TypeSpecificValue = 0;
                return;
            }
            // Channelers can spend mana instead of a charge
            bool channeled = false;
            if (saveGame.Player.Spellcasting.Type == CastingType.Channeling)
            {
                channeled = saveGame.DoCmdChannel(item);
                if (channeled)
                {
                    item.TypeSpecificValue = 0;
                }
            }
            if (!channeled)
            {
                // If the rod was part of a stack, remove it
                if (itemIndex >= 0 && item.Count > 1)
                {
                    Item singleRod = new Item(item) { Count = 1 };
                    item.TypeSpecificValue = 0;
                    item.Count--;
                    saveGame.Player.WeightCarried -= singleRod.Weight;
                    saveGame.Player.Inventory.InvenCarry(singleRod, false);
                    saveGame.MsgPrint("You unstack your rod.");
                }
            }
        }

    }
}
