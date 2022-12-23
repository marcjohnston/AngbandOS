using AngbandOS.Core;
using AngbandOS.Core.EventArgs;
using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Core.ItemFilters;
using AngbandOS.Enumerations;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Use a staff from the inventory or floor
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the item to use </param>
    [Serializable]
    internal class UseStaffCommand : ICommand
    {
        private UseStaffCommand(SaveGame saveGame) { } // This object is a singleton.

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

            StaffItemClass staffItem = (StaffItemClass)item.BaseItemCategory;

            // We can't use a staff from the floor
            if (itemIndex < 0 && item.Count > 1)
            {
                saveGame.MsgPrint("You must first pick up the staff.");
                return;
            }
            // Using a staff costs a full turn
            saveGame.EnergyUse = 100;
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
            UseStaffEvent eventArgs = new UseStaffEvent(saveGame);

            // Do the specific effect for the type of staff
            staffItem.UseStaff(eventArgs);

            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // We might now know what the staff does
            item.ObjectTried();
            if (eventArgs.Identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            // We may not have used up a charge
            if (!eventArgs.ChargeUsed)
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
