using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;
using AngbandOS.ItemCategories;
using AngbandOS.Core;
using AngbandOS.Core.ItemFilters;

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
                if (!saveGame.GetItem(out itemIndex, "Eat which item? ", false, true, true, new ItemCategoryItemFilter(ItemCategory.Food)))
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
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemCategory.Food)))
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
            FoodItemCategory foodItem = (FoodItemCategory)item.BaseItemCategory;
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
            // Vampires only get 1/10th of the food value
            if (saveGame.Player.RaceIndex == RaceId.Vampire)
            {
                _ = saveGame.Player.SetFood(saveGame.Player.Food + (item.TypeSpecificValue / 10));
                saveGame.MsgPrint("Mere victuals hold scant sustenance for a being such as yourself.");
                if (saveGame.Player.Food < Constants.PyFoodAlert)
                {
                    saveGame.MsgPrint("Your hunger can only be satisfied with fresh blood!");
                }
            }
            // Skeletons get no food sustenance
            else if (saveGame.Player.RaceIndex == RaceId.Skeleton)
            {
                if (!(item.ItemSubCategory == FoodType.Waybread || item.ItemSubCategory == FoodType.Warpstone ||
                      item.ItemSubCategory < FoodType.Biscuit))
                {
                    // Spawn a new food item on the floor to make up for the one that will be destroyed
                    Item floorItem = new Item(saveGame);
                    saveGame.MsgPrint("The food falls through your jaws!");
                    floorItem.AssignItemType(item.BaseItemCategory);
                    saveGame.Level.DropNear(floorItem, -1, saveGame.Player.MapY, saveGame.Player.MapX);
                }
                else
                {
                    // But some magical types work anyway and then vanish
                    saveGame.MsgPrint("The food falls through your jaws and vanishes!");
                }
            }
            // Golems, zombies, and spectres get only 1/20th of the food value
            else if (saveGame.Player.RaceIndex == RaceId.Golem || saveGame.Player.RaceIndex == RaceId.Zombie || saveGame.Player.RaceIndex == RaceId.Spectre)
            {
                saveGame.MsgPrint("The food of mortals is poor sustenance for you.");
                saveGame.Player.SetFood(saveGame.Player.Food + (item.TypeSpecificValue / 20));
            }
            // Everyone else gets the full value
            else
            {
                saveGame.Player.SetFood(saveGame.Player.Food + item.TypeSpecificValue);
            }
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
