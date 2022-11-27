using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;
using AngbandOS.Core;
using AngbandOS.Core.ItemFilters;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Use a staff from the inventory or floor
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the item to use </param>
    [Serializable]
    internal class UseStaffCommand : ICommand
    {
        public char Key => 'u';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;

            // Get an item if we weren't passed one
            if (itemIndex == -999)
            {
                if (!saveGame.GetItem(out itemIndex, "Use which staff? ", false, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Staff)))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have no staff to use.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Make sure the item is actually a staff
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Staff)))
            {
                saveGame.MsgPrint("That is not a staff!");
                return;
            }
            // We can't use a staff from the floor
            if (itemIndex < 0 && item.Count > 1)
            {
                saveGame.MsgPrint("You must first pick up the staffs.");
                return;
            }
            // Using a staff costs a full turn
            saveGame.EnergyUse = 100;
            bool identified = false;
            int itemLevel = item.BaseItemCategory.Level;
            // We have a chance of the device working equal to skill (halved if confused) - item
            // level (capped at 50)
            int chance = saveGame.Player.SkillUseDevice;
            if (saveGame.Player.TimedConfusion != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // Always a small chance of it working
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            // Check to see if we use it properly
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                saveGame.MsgPrint("You failed to use the staff properly.");
                return;
            }
            // Make sure it has charges left
            if (item.TypeSpecificValue <= 0)
            {
                saveGame.MsgPrint("The staff has no charges left.");
                item.IdentEmpty = true;
                return;
            }
            saveGame.PlaySound(SoundEffect.UseStaff);
            int k;
            bool useCharge = true;
            // Do the specific effect for the type of staff
            switch (item.ItemSubCategory)
            {
                case StaffType.Darkness:
                    {
                        if (!saveGame.Player.HasBlindnessResistance && !saveGame.Player.HasDarkResistance)
                        {
                            if (saveGame.Player.SetTimedBlindness(saveGame.Player.TimedBlindness + 3 + Program.Rng.DieRoll(5)))
                            {
                                identified = true;
                            }
                        }
                        if (saveGame.UnlightArea(10, 3))
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.Slowness:
                    {
                        if (saveGame.Player.SetTimedSlow(saveGame.Player.TimedSlow + Program.Rng.DieRoll(30) + 15))
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.HasteMonsters:
                    {
                        if (saveGame.HasteMonsters())
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.Summoning:
                    {
                        for (k = 0; k < Program.Rng.DieRoll(4); k++)
                        {
                            if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, null))
                            {
                                identified = true;
                            }
                        }
                        break;
                    }
                case StaffType.Teleportation:
                    {
                        saveGame.TeleportPlayer(100);
                        identified = true;
                        break;
                    }
                case StaffType.Identify:
                    {
                        if (!saveGame.IdentifyItem())
                        {
                            useCharge = false;
                        }
                        identified = true;
                        break;
                    }
                case StaffType.RemoveCurse:
                    {
                        if (saveGame.RemoveCurse())
                        {
                            if (saveGame.Player.TimedBlindness == 0)
                            {
                                saveGame.MsgPrint("The staff glows blue for a moment...");
                            }
                            identified = true;
                        }
                        break;
                    }
                case StaffType.Starlight:
                    {
                        if (saveGame.Player.TimedBlindness == 0)
                        {
                            saveGame.MsgPrint("The end of the staff glows brightly...");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            saveGame.LightLine(saveGame.Level.OrderedDirection[k]);
                        }
                        identified = true;
                        break;
                    }
                case StaffType.Light:
                    {
                        if (saveGame.LightArea(Program.Rng.DiceRoll(2, 8), 2))
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.Mapping:
                    {
                        saveGame.Level.MapArea();
                        identified = true;
                        break;
                    }
                case StaffType.DetectGold:
                    {
                        if (saveGame.DetectTreasure())
                        {
                            identified = true;
                        }
                        if (saveGame.DetectObjectsGold())
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.DetectItem:
                    {
                        if (saveGame.DetectObjectsNormal())
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.DetectTrap:
                    {
                        if (saveGame.DetectTraps())
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.DetectDoor:
                    {
                        if (saveGame.DetectDoors())
                        {
                            identified = true;
                        }
                        if (saveGame.DetectStairs())
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.DetectInvis:
                    {
                        if (saveGame.DetectMonstersInvis())
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.DetectEvil:
                    {
                        if (saveGame.DetectMonstersEvil())
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.CureLight:
                    {
                        if (saveGame.Player.RestoreHealth(Program.Rng.DieRoll(8)))
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.Curing:
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
                        break;
                    }
                case StaffType.Healing:
                    {
                        if (saveGame.Player.RestoreHealth(300))
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
                        break;
                    }
                case StaffType.TheMagi:
                    {
                        if (saveGame.Player.TryRestoringAbilityScore(Ability.Intelligence))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.Mana < saveGame.Player.MaxMana)
                        {
                            saveGame.Player.Mana = saveGame.Player.MaxMana;
                            saveGame.Player.FractionalMana = 0;
                            identified = true;
                            saveGame.MsgPrint("Your feel your head clear.");
                            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMana);
                        }
                        break;
                    }
                case StaffType.SleepMonsters:
                    {
                        if (saveGame.SleepMonsters())
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.SlowMonsters:
                    {
                        if (saveGame.SlowMonsters())
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.Speed:
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
                        break;
                    }
                case StaffType.Probing:
                    {
                        saveGame.Probing();
                        identified = true;
                        break;
                    }
                case StaffType.DispelEvil:
                    {
                        if (saveGame.DispelEvil(60))
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.Power:
                    {
                        if (saveGame.DispelMonsters(120))
                        {
                            identified = true;
                        }
                        break;
                    }
                case StaffType.Holiness:
                    {
                        if (saveGame.DispelEvil(120))
                        {
                            identified = true;
                        }
                        k = 3 * saveGame.Player.Level;
                        if (saveGame.Player.SetTimedProtectionFromEvil(saveGame.Player.TimedProtectionFromEvil + Program.Rng.DieRoll(25) + k))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.SetTimedPoison(0))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.SetTimedFear(0))
                        {
                            identified = true;
                        }
                        if (saveGame.Player.RestoreHealth(50))
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
                        break;
                    }
                case StaffType.Carnage:
                    {
                        saveGame.Carnage(true);
                        identified = true;
                        break;
                    }
                case StaffType.Earthquakes:
                    {
                        saveGame.Earthquake(saveGame.Player.MapY, saveGame.Player.MapX, 10);
                        identified = true;
                        break;
                    }
                case StaffType.Destruction:
                    {
                        saveGame.DestroyArea(saveGame.Player.MapY, saveGame.Player.MapX, 15);
                        identified = true;
                        break;
                    }
            }
            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // We might now know what the staff does
            item.ObjectTried();
            if (identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            // We may not have used up a charge
            if (!useCharge)
            {
                return;
            }
            // Channelers can use mana instead of a charge
            bool channeled = false;
            if (saveGame.Player.Spellcasting.Type == CastingType.Channeling)
            {
                channeled = saveGame.DoCmdChannel(item);
            }
            if (!channeled)
            {
                // Use the actual charge
                item.TypeSpecificValue--;
                // If the staff was part of a stack, separate it from the rest
                if (itemIndex >= 0 && item.Count > 1)
                {
                    Item singleStaff = new Item(saveGame, item) { Count = 1 };
                    item.TypeSpecificValue++;
                    item.Count--;
                    saveGame.Player.WeightCarried -= singleStaff.Weight;
                    itemIndex = saveGame.Player.Inventory.InvenCarry(singleStaff, false);
                    saveGame.MsgPrint("You unstack your staff.");
                }
                // Let the player know what happened
                if (itemIndex >= 0)
                {
                    saveGame.Player.Inventory.ReportChargeUsageFromInventory(itemIndex);
                }
                else
                {
                    saveGame.Level.ReportChargeUsageFromFloor(0 - itemIndex);
                }
            }
        }

    }
}
