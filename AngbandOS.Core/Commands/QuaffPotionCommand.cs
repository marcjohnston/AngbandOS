using Cthangband.Enumerations;
using Cthangband.StaticData;
using AngbandOS.Core.Interface;

namespace Cthangband.Commands
{
    /// <summary>
    /// Quaff a potion from the inventory or the ground
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the potion to quaff </param>
    [Serializable]
    internal class QuaffPotionCommand : ICommand
    {
        public char Key => 'q';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;

            // Get an item if we didn't already have one
            Inventory.ItemFilterCategory = ItemCategory.Potion;
            if (itemIndex == -999)
            {
                if (!saveGame.GetItem(out itemIndex, "Quaff which potion? ", true, true, true))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have no potions to quaff.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Make sure the item is a potion
            Inventory.ItemFilterCategory = ItemCategory.Potion;
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item))
            {
                saveGame.MsgPrint("That is not a potion!");
                return;
            }
            Inventory.ItemFilterCategory = 0;
            saveGame.PlaySound(SoundEffect.Quaff);
            // Drinking a potion costs a whole turn
            saveGame.EnergyUse = 100;
            int itemLevel = item.ItemType.Level;
            // Do the actual potion effect
            bool identified = saveGame.PotionEffect(item.ItemSubCategory);
            // Skeletons are messy drinkers
            if (saveGame.Player.RaceIndex == RaceId.Skeleton && Program.Rng.DieRoll(12) == 1)
            {
                saveGame.MsgPrint("Some of the fluid falls through your jaws!");
                saveGame.PotionSmashEffect(0, saveGame.Player.MapY, saveGame.Player.MapX, item.ItemSubCategory);
            }
            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // We may now know the potion's type
            item.ObjectTried();
            if (identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            // Most potions give us a bit of food too
            saveGame.Player.SetFood(saveGame.Player.Food + item.TypeSpecificValue);
            bool channeled = false;
            // If we're a channeler, we might be able to spend mana instead of using it up
            if (saveGame.Player.Spellcasting.Type == CastingType.Channeling)
            {
                channeled = saveGame.DoCmdChannel(item);
            }
            if (!channeled)
            {
                // We didn't channel it, so use up one potion from the stack
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
