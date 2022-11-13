using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core;
using AngbandOS.Core.ItemFilters;
using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Eat some food
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the food item </param>
    [Serializable]
    internal class EatFoodCommand : ICommand
    {
        public char Key => 'E';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;
            // Get a food item from the inventory if one wasn't already specified
            if (itemIndex == -999)
            {
                if (!saveGame.GetItem(out itemIndex, "Eat which item? ", false, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Food)))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have nothing to eat.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Make sure the item is edible
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Food)))
            {
                saveGame.MsgPrint("You can't eat that!");
                return;
            }
            // We don't actually eat dwarf bread
            if (item.ItemSubCategory != FoodType.Dwarfbread)
            {
                saveGame.PlaySound(SoundEffect.Eat);
            }
            // Eating costs 100 energy
            saveGame.EnergyUse = 100;
            bool ident = false;
            int itemLevel = item.BaseItemCategory.Level;
            FoodItemClass foodItem = (FoodItemClass)item.BaseItemCategory;

            // Allow the food item to process the consumption.
            foodItem.Eat(saveGame);           

            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // We've tried this type of object
            item.ObjectTried();
            // Learn its flavour if necessary
            if (ident && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            // Dwarf bread isn't actually eaten so reduce our hunger and return early
            if (item.ItemSubCategory == FoodType.Dwarfbread)
            {
                saveGame.Player.SetFood(saveGame.Player.Food + item.TypeSpecificValue);
                return;
            }

            // Now races process the sustenance.
            saveGame.Player.Race.Eat(saveGame, item);

            // Use up the item (if it fell to the floor this will have already been dealt with)
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
