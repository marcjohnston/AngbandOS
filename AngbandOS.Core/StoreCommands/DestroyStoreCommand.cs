using AngbandOS.Commands;
using AngbandOS.Core;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Destroy a single item
    /// </summary>
    [Serializable]
    internal class DestroyStoreCommand : IStoreCommand
    {
        public char Key => 'k';

        public bool IsEnabled(Store store) => true;

        public string Description => "";

        public bool RequiresRerendering => false;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdDestroy(saveGame);
        }

        public static void DoCmdDestroy(SaveGame saveGame)
        {
            int amount = 1;
            bool force = saveGame.CommandArgument > 0;
            // Get an item to destroy
            if (!saveGame.GetItem(out int itemIndex, "Destroy which item? ", false, true, true))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have nothing to destroy.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // If we have more than one we might not want to destroy all of them
            if (item.Count > 1)
            {
                amount = saveGame.GetQuantity(null, item.Count, true);
                if (amount <= 0)
                {
                    return;
                }
            }
            int oldNumber = item.Count;
            item.Count = amount;
            string itemName = item.Description(true, 3);
            item.Count = oldNumber;
            //Only confirm if it's not a worthless item
            if (!force)
            {
                if (!item.Stompable())
                {
                    string outVal = $"Really destroy {itemName}? ";
                    if (!saveGame.GetCheck(outVal))
                    {
                        return;
                    }
                    // If it was something we might want to destroy again, ask
                    if (!item.ItemType.HasQuality() && item.ItemType.BaseItemCategory.CategoryEnum != ItemCategory.Chest)
                    {
                        if (item.IsKnown())
                        {
                            if (saveGame.GetCheck($"Always destroy {itemName}?"))
                            {
                                item.ItemType.BaseItemCategory.Stompable[0] = true;
                            }
                        }
                    }
                }
            }
            // Destroying something takes a turn
            saveGame.EnergyUse = 100;
            // Can't destroy an artifact artifact
            if (item.IsFixedArtifact() || !string.IsNullOrEmpty(item.RandartName))
            {
                string feel = "special";
                saveGame.EnergyUse = 0;
                saveGame.MsgPrint($"You cannot destroy {itemName}.");
                if (item.IsCursed() || item.IsBroken())
                {
                    feel = "terrible";
                }
                item.Inscription = feel;
                item.IdentifyFlags.Set(Constants.IdentSense);
                saveGame.Player.NoticeFlags |= Constants.PnCombine;
                saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrEquippy);
                return;
            }
            saveGame.MsgPrint($"You destroy {itemName}.");
            // Warriors and paladins get experience for destroying magic books
            if (saveGame.ItemFilterHighLevelBook(item))
            {
                bool gainExpr = false;
                if (saveGame.Player.ProfessionIndex == CharacterClass.Warrior)
                {
                    gainExpr = true;
                }
                else if (saveGame.Player.ProfessionIndex == CharacterClass.Paladin)
                {
                    if (saveGame.Player.Realm1 == Realm.Life)
                    {
                        if (item.Category == ItemCategory.DeathBook)
                        {
                            gainExpr = true;
                        }
                    }
                    else
                    {
                        if (item.Category == ItemCategory.LifeBook)
                        {
                            gainExpr = true;
                        }
                    }
                }
                if (gainExpr && saveGame.Player.ExperiencePoints < Constants.PyMaxExp)
                {
                    int testerExp = saveGame.Player.MaxExperienceGained / 20;
                    if (testerExp > 10000)
                    {
                        testerExp = 10000;
                    }
                    if (item.ItemSubCategory < 3)
                    {
                        testerExp /= 4;
                    }
                    if (testerExp < 1)
                    {
                        testerExp = 1;
                    }
                    saveGame.MsgPrint("You feel more experienced.");
                    saveGame.Player.GainExperience(testerExp * amount);
                }
            }
            // Tidy up the player's inventory
            if (itemIndex >= 0)
            {
                saveGame.Player.Inventory.InvenItemIncrease(itemIndex, -amount);
                saveGame.Player.Inventory.InvenItemDescribe(itemIndex);
                saveGame.Player.Inventory.InvenItemOptimize(itemIndex);
            }
            else
            {
                saveGame.Level.FloorItemIncrease(0 - itemIndex, -amount);
                saveGame.Level.FloorItemDescribe(0 - itemIndex);
                saveGame.Level.FloorItemOptimize(0 - itemIndex);
            }
        }
    }
}
