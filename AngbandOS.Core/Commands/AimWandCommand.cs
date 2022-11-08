using AngbandOS.Enumerations;
using AngbandOS.Projection;
using AngbandOS.Core.Interface;
using AngbandOS.ItemCategories;
using AngbandOS.Core;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Aim a wand from your inventory
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the wand, or -999 to select one </param>
    [Serializable]
    internal class AimWandCommand : ICommand
    {
        public char Key => 'a';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;
            if (itemIndex == -999)
            {
                // Prompt for an item, showing only wands
                Inventory.ItemFilterCategory = ItemCategory.Wand;
                if (!saveGame.GetItem(out itemIndex, "Aim which wand? ", true, true, true))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have no wand to aim.");
                    }
                    return;
                }
            }
            // Get the item and check if it is really a wand
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            Inventory.ItemFilterCategory = ItemCategory.Wand;
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item))
            {
                saveGame.MsgPrint("That is not a wand!");
                Inventory.ItemFilterCategory = 0;
                return;
            }
            Inventory.ItemFilterCategory = 0;
            // We can't use wands directly from the floor, since we need to aim them
            if (itemIndex < 0 && item.Count > 1)
            {
                saveGame.MsgPrint("You must first pick up the wand.");
                return;
            }
            // Aim the wand
            TargetEngine targetEngine = new TargetEngine(saveGame);
            if (!targetEngine.GetDirectionWithAim(out int dir))
            {
                return;
            }
            // Using a wand takes 100 energy
            saveGame.EnergyUse = 100;
            bool ident = false;
            int itemLevel = item.BaseItemCategory.Level;
            // Chance of success is your skill - item level, with item level capped at 50 and your
            // skill halved if you're confused
            int chance = saveGame.Player.SkillUseDevice;
            if (saveGame.Player.TimedConfusion != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // Always a small chance of success
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                saveGame.MsgPrint("You failed to use the wand properly.");
                return;
            }
            // Make sure we have charges
            if (item.TypeSpecificValue <= 0)
            {
                saveGame.MsgPrint("The wand has no charges left.");
                item.IdentifyFlags.Set(Constants.IdentEmpty);
                return;
            }
            saveGame.PlaySound(SoundEffect.ZapRod);
            int subCategory = item.ItemSubCategory;
            WandItemCategory activateableItem = (WandItemCategory)item.BaseItemCategory;
            if (activateableItem.ExecuteActivation(saveGame, dir))
                ident = true;

            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // Mark the wand as having been tried
            item.ObjectTried();
            // If we just discovered the item's flavour, mark it as so
            if (ident && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            // If we're a channeler then we should be using mana instead of charges
            bool channeled = false;
            if (saveGame.Player.Spellcasting.Type == CastingType.Channeling)
            {
                channeled = saveGame.DoCmdChannel(item);
            }
            // We didn't use mana, so decrease the wand's charges
            if (!channeled)
            {
                item.TypeSpecificValue--;
                // If the wand is part of a stack, split it off from the others
                if (itemIndex >= 0 && item.Count > 1)
                {
                    Item splitItem = new Item(saveGame, item) { Count = 1 };
                    item.TypeSpecificValue++;
                    item.Count--;
                    saveGame.Player.WeightCarried -= splitItem.Weight;
                    itemIndex = saveGame.Player.Inventory.InvenCarry(splitItem, false);
                    saveGame.MsgPrint("You unstack your wand.");
                }
                // Let us know we have used a charge
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
