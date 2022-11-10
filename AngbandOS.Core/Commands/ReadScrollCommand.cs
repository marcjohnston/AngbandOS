using AngbandOS.Core;
using AngbandOS.Core.ItemFilters;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Read a scroll from the inventory or floor
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the scroll to be read </param>
    [Serializable]
    internal class ReadScrollCommand : ICommand
    {
        public char Key => 'r';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;

            int i;
            // Make sure we're in a situation where we can read
            if (saveGame.Player.TimedBlindness != 0)
            {
                saveGame.MsgPrint("You can't see anything.");
                return;
            }
            if (saveGame.Level.NoLight())
            {
                saveGame.MsgPrint("You have no light to read by.");
                return;
            }
            if (saveGame.Player.TimedConfusion != 0)
            {
                saveGame.MsgPrint("You are too confused!");
                return;
            }
            // If we weren't passed in an item, prompt for one
            if (itemIndex == -999)
            {
                if (!saveGame.GetItem(out itemIndex, "Read which scroll? ", true, true, true, new ItemCategoryItemFilter(ItemCategory.Scroll)))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have no scrolls to read.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Make sure the item is actually a scroll
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemCategory.Scroll)))
            {
                saveGame.MsgPrint("That is not a scroll!");
                return;
            }
            // Scrolls use a full turn
            saveGame.EnergyUse = 100;
            ScrollItemCategory scrollItem = (ScrollItemCategory)item.BaseItemCategory;
            ReadScrollEvent readScrollEventArgs = new ReadScrollEvent(saveGame);
            scrollItem.Read(readScrollEventArgs);
            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // We might have just identified the scroll
            item.ObjectTried();
            if (readScrollEventArgs.Identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                int itemLevel = item.BaseItemCategory.Level;
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            bool channeled = false;
            // Channelers can use mana instead of the scroll being used up
            if (saveGame.Player.Spellcasting.Type == CastingType.Channeling)
            {
                channeled = saveGame.DoCmdChannel(item);
            }
            if (!channeled)
            {
                if (!readScrollEventArgs.UsedUp)
                {
                    return;
                }
                // If it wasn't used up then decrease the amount in the stack
                if (itemIndex >= 0)
                {
                    saveGame.Player.Inventory.InvenItemIncrease(itemIndex, -1);
                    saveGame.Player.Inventory.InvenItemDescribe(itemIndex);
                    saveGame.Player.Inventory.InvenItemOptimize(itemIndex);
                }
                else
                {
                    saveGame.Level.FloorItemIncrease(0 - itemIndex, -1);
                    saveGame.Level.FloorItemDescribe(0 - itemIndex);
                    saveGame.Level.FloorItemOptimize(0 - itemIndex);
                }
            }
        }

    }
}
