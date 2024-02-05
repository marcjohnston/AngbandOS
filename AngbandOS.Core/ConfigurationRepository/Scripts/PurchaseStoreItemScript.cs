// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PurchaseStoreItemScript : Script, IStoreScript
{
    private PurchaseStoreItemScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Allows the selection of and purchase of an item from the store.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        int itemNew;
        string oName;
        if (storeCommandEvent.Store.StoreInventoryList.Count <= 0)
        {
            SaveGame.MsgPrint(storeCommandEvent.Store.StoreFactory.NoStockMessage);
            return;
        }
        int i = storeCommandEvent.Store.StoreInventoryList.Count - storeCommandEvent.Store.StoreTop;
        if (i > storeCommandEvent.Store.StoreFactory.PageSize)
        {
            i = storeCommandEvent.Store.StoreFactory.PageSize;
        }
        string outVal = storeCommandEvent.Store.StoreFactory.PurchaseMessage;
        if (!storeCommandEvent.Store.GetStock(out int letterIndex, outVal, 0, i - 1))
        {
            return;
        }
        int inventoryItemIndex = letterIndex + storeCommandEvent.Store.StoreTop;
        Item oPtr = storeCommandEvent.Store.StoreInventoryList[inventoryItemIndex];
        int amt = 1;
        Item jPtr = oPtr.Clone(amt);
        if (!SaveGame.InvenCarryOkay(jPtr))
        {
            SaveGame.MsgPrint("You cannot carry that many different items.");
            return;
        }
        int best = storeCommandEvent.Store.MarkupItem(jPtr);
        if (oPtr.Count > 1)
        {
            if (storeCommandEvent.Store.StoreFactory.StoreSellsItems && oPtr.IdentFixed)
            {
                SaveGame.MsgPrint($"That costs {best} gold per item.");
            }
            int maxBuy = Math.Min(SaveGame.Gold / best, oPtr.Count);
            if (maxBuy < 2)
            {
                amt = 1;
            }
            else
            {
                amt = SaveGame.GetQuantity(null, maxBuy, false);
                if (amt <= 0)
                {
                    return;
                }
            }
        }
        jPtr = oPtr.Clone(amt);
        if (!SaveGame.InvenCarryOkay(jPtr))
        {
            SaveGame.MsgPrint("You cannot carry that many items.");
            return;
        }
        if (storeCommandEvent.Store.StoreFactory.StoreSellsItems)
        {
            bool choice;
            int price;
            if (oPtr.IdentFixed)
            {
                choice = false;
                price = best * jPtr.Count;
            }
            else
            {
                oName = storeCommandEvent.Store.StoreFactory.GetItemDescription(jPtr);
                SaveGame.MsgPrint($"Buying {oName} ({letterIndex.IndexToLetter()}).");
                SaveGame.MsgPrint(null);
                choice = PurchaseHaggle(storeCommandEvent.Store, jPtr, out price);
            }
            if (!choice)
            {
                if (SaveGame.Gold >= price)
                {
                    SaveGame.SayComment_1();
                    SaveGame.PlaySound(SoundEffectEnum.StoreTransaction);
                    SaveGame.Gold -= price;
                    SaveGame.StorePrtGold();
                    //if (storeCommandEvent.Store.StoreFactory.StoreIdentifiesItems)
                    //{
                    //    jPtr.BecomeFlavourAware();
                    //}
                    jPtr.IdentFixed = false;
                    oName = jPtr.Description(true, 3);
                    
                    if (storeCommandEvent.Store.StoreFactory.BoughtMessageAsBoughtBack)
                    {
                        SaveGame.MsgPrint($"You bought back {oName} for {price} gold.");
                    }
                    else
                    {
                        SaveGame.MsgPrint($"You bought {oName} for {price} gold.");
                    }
                    jPtr.Inscription = "";
                    itemNew = SaveGame.InvenCarry(jPtr);
                    Item? newItemInInventory = SaveGame.GetInventoryItem(itemNew);
                    if (newItemInInventory == null)
                    {
                        return; // TODO: This should never be.
                    }
                    oName = newItemInInventory.Description(true, 3);
                    SaveGame.MsgPrint($"You have {oName} ({itemNew.IndexToLabel()}).");
                    SaveGame.HandleStuff();
                    i = storeCommandEvent.Store.StoreInventoryList.Count;
                    storeCommandEvent.Store.StoreItemIncrease(inventoryItemIndex, -amt);
                    storeCommandEvent.Store.StoreItemOptimize(inventoryItemIndex);

                    // Ensure the inventory scrolls as needed.
                    storeCommandEvent.Store.ScrollInventory(0);

                    // Check to see if the store was bought out.
                    if (storeCommandEvent.Store.StoreInventoryList.Count == 0)
                    {
                        if (storeCommandEvent.Store.StoreFactory.MaintainsStockLevels)
                        {
                            if (SaveGame.Rng.RandomLessThan(Constants.StoreShuffle) == 0)
                            {
                                SaveGame.MsgPrint("The shopkeeper retires.");
                                storeCommandEvent.Store.StoreShuffle();
                            }
                            else
                            {
                                SaveGame.MsgPrint("The shopkeeper brings out some new stock.");
                            }
                            for (i = 0; i < 10; i++)
                            {
                                storeCommandEvent.Store.StoreMaint();
                            }
                        }
                    }

                    // Rerender the inventory.
                    storeCommandEvent.Store.DisplayInventory();
                }
                else
                {
                    SaveGame.MsgPrint("You do not have enough gold.");
                }
            }
        }
        else
        {
            itemNew = SaveGame.InvenCarry(jPtr);
            Item? newItemInInventory = SaveGame.GetInventoryItem(itemNew);
            if (newItemInInventory == null)
            {
                return; // TODO: This should never be.
            }
            oName = newItemInInventory.Description(true, 3);
            SaveGame.MsgPrint($"You have {oName} ({itemNew.IndexToLabel()}).");
            SaveGame.HandleStuff();
            i = storeCommandEvent.Store.StoreInventoryList.Count;
            storeCommandEvent.Store.StoreItemIncrease(inventoryItemIndex, -amt);
            storeCommandEvent.Store.StoreItemOptimize(inventoryItemIndex);
            if (i == storeCommandEvent.Store.StoreInventoryList.Count)
            {
                storeCommandEvent.Store.DisplayEntry(inventoryItemIndex, letterIndex.IndexToLetter(), letterIndex + 6);
            }
            else
            {
                if (storeCommandEvent.Store.StoreInventoryList.Count == 0)
                {
                    storeCommandEvent.Store.ScrollToItem(0);
                }
                else if (storeCommandEvent.Store.StoreTop >= storeCommandEvent.Store.StoreInventoryList.Count)
                {
                    storeCommandEvent.Store.ScrollToItem(storeCommandEvent.Store.StoreInventoryList.Count);
                }
                storeCommandEvent.Store.DisplayInventory();
            }
        }
    }

    private bool PurchaseHaggle(Store store, Item oPtr, out int price)
    {
        int finalAsk = store.MarkupItem(oPtr);
        SaveGame.MsgPrint("You quickly agree upon the price.");
        SaveGame.MsgPrint(null);
        finalAsk += finalAsk / 10;
        const string pmt = "Final Offer";
        finalAsk *= oPtr.Count;
        price = finalAsk;
        string outVal = $"{pmt} :  {finalAsk}";
        SaveGame.Screen.Print(outVal, 1, 0);
        return !SaveGame.GetCheck("Accept deal? ");
    }
}
