﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PurchaseStoreItemScript : Script, IScriptStore
{
    private PurchaseStoreItemScript(Game game) : base(game) { }

    /// <summary>
    /// Allows the selection of and purchase of an item from the store.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptStore(StoreCommandEvent storeCommandEvent)
    {
        int itemNew;
        string oName;
        if (storeCommandEvent.Store.StoreInventoryList.Count <= 0)
        {
            Game.MsgPrint(storeCommandEvent.Store.StoreFactory.NoStockMessage);
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
        if (!Game.InvenCarryOkay(jPtr))
        {
            Game.MsgPrint("You cannot carry that many different items.");
            return;
        }
        int best = storeCommandEvent.Store.MarkupItem(jPtr);
        if (oPtr.Count > 1)
        {
            if (storeCommandEvent.Store.StoreFactory.StoreSellsItems && oPtr.IdentFixed)
            {
                Game.MsgPrint($"That costs {best} gold per item.");
            }
            int maxBuy = Math.Min(Game.Gold.IntValue / best, oPtr.Count);
            if (maxBuy < 2)
            {
                amt = 1;
            }
            else
            {
                amt = Game.GetQuantity(maxBuy, false);
                if (amt <= 0)
                {
                    return;
                }
            }
        }
        jPtr = oPtr.Clone(amt);
        if (!Game.InvenCarryOkay(jPtr))
        {
            Game.MsgPrint("You cannot carry that many items.");
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
                oName = jPtr.GetFullDescription(true);
                Game.MsgPrint($"Buying {oName} ({letterIndex.IndexToLetter()}).");
                Game.MsgPrint(null);
                choice = PurchaseHaggle(storeCommandEvent.Store, jPtr, out price);
            }
            if (!choice)
            {
                if (Game.Gold.IntValue >= price)
                {
                    Game.SayComment_1();
                    Game.PlaySound(SoundEffectEnum.StoreTransaction);
                    Game.Gold.IntValue -= price;
                    Game.StorePrtGold();
                    //if (storeCommandEvent.Store.StoreFactory.StoreIdentifiesItems)
                    //{
                    //    jPtr.BecomeFlavorAware();
                    //}
                    jPtr.IdentFixed = false;
                    oName = jPtr.GetFullDescription(true);
                    
                    if (storeCommandEvent.Store.StoreFactory.BoughtMessageAsBoughtBack)
                    {
                        Game.MsgPrint($"You bought back {oName} for {price} gold.");
                    }
                    else
                    {
                        Game.MsgPrint($"You bought {oName} for {price} gold.");
                    }
                    jPtr.Inscription = "";
                    itemNew = Game.InvenCarry(jPtr);
                    Item? newItemInInventory = Game.GetInventoryItem(itemNew);
                    if (newItemInInventory == null)
                    {
                        return; // TODO: This should never be.
                    }
                    oName = newItemInInventory.GetFullDescription(true);
                    Game.MsgPrint($"You have {oName} ({itemNew.IndexToLabel()}).");
                    Game.HandleStuff();
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
                            if (Game.RandomLessThan(Constants.StoreShuffle) == 0)
                            {
                                Game.MsgPrint("The shopkeeper retires.");
                                storeCommandEvent.Store.StoreShuffle();
                            }
                            else
                            {
                                Game.MsgPrint("The shopkeeper brings out some new stock.");
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
                    Game.MsgPrint("You do not have enough gold.");
                }
            }
        }
        else
        {
            itemNew = Game.InvenCarry(jPtr);
            Item? newItemInInventory = Game.GetInventoryItem(itemNew);
            if (newItemInInventory == null)
            {
                return; // TODO: This should never be.
            }
            oName = newItemInInventory.GetFullDescription(true);
            Game.MsgPrint($"You have {oName} ({itemNew.IndexToLabel()}).");
            Game.HandleStuff();
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
        Game.MsgPrint("You quickly agree upon the price.");
        Game.MsgPrint(null);
        finalAsk += finalAsk / 10;
        const string pmt = "Final Offer";
        finalAsk *= oPtr.Count;
        price = finalAsk;
        string outVal = $"{pmt} :  {finalAsk}";
        Game.Screen.Print(outVal, 1, 0);
        return !Game.GetCheck("Accept deal? ");
    }
}
