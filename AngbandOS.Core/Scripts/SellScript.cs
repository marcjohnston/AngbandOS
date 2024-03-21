// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SellScript : Script, IStoreScript
{
    private SellScript(Game game) : base(game) { }

    /// <summary>
    /// Allows an item to be sold to the store.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        if (!storeCommandEvent.Store.StoreFactory.StoreMaintainsInventory)
        {
            Game.MsgPrint("This store has no interest in your earthly possessions.");
        }

        int itemPos;
        if (!Game.SelectItem(out Item? oPtr, storeCommandEvent.Store.StoreFactory.SellPrompt, true, true, false, storeCommandEvent.Store.StoreFactory)) // We use the store itself as the ItemFilter because the Store implements IItemFilter.
        {
            Game.MsgPrint("You have nothing that I want.");
            return;
        }
        if (oPtr == null)
        {
            return;
        }
        if (oPtr.IsInEquipment && oPtr.IsCursed())
        {
            Game.MsgPrint("Hmmm, it seems to be cursed.");
            return;
        }
        int amt = 1;
        if (oPtr.Count > 1)
        {
            amt = Game.GetQuantity(null, oPtr.Count, true);
            if (amt <= 0)
            {
                return;
            }
        }
        Item qPtr = oPtr.Clone();
        qPtr.Count = amt;
        string oName = qPtr.Description(true, 3);
        if (!storeCommandEvent.Store.StoreFactory.StoreMaintainsInscription)
        {
            qPtr.Inscription = "";
        }
        if (!storeCommandEvent.Store.StoreCanAcceptMoreItems(qPtr))
        {
            Game.MsgPrint(storeCommandEvent.Store.StoreFactory.StoreFullMessage);
            return;
        }
        if (storeCommandEvent.Store.StoreFactory.StoreBuysItems)
        {
            Game.MsgPrint($"Selling {oName} ({oPtr.Label}).");
            Game.MsgPrint(null);
            bool accepted = SellHaggle(storeCommandEvent.Store, qPtr, out int price);
            if (!accepted)
            {
                return;
            }
            Game.SayComment_1();
            Game.PlaySound(SoundEffectEnum.StoreTransaction);
            Game.Gold.Value += price;
            Game.StorePrtGold();
            int guess = qPtr.Value() * qPtr.Count;
            if (storeCommandEvent.Store.StoreFactory.StoreIdentifiesItems)
            {
                oPtr.BecomeFlavorAware();
                oPtr.BecomeKnown();
            }
            Game.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
            qPtr = oPtr.Clone();
            qPtr.Count = amt;
            int value;
            if (!storeCommandEvent.Store.StoreFactory.StoreAnalyzesPurchases)
            {
                value = guess;
            }
            else
            {
                value = qPtr.Value() * qPtr.Count;
                oName = qPtr.Description(true, 3);
            }
            Game.MsgPrint($"You {storeCommandEvent.Store.StoreFactory.BoughtVerb} {oName} for {price} gold.");
            PurchaseAnalyze(price, value, guess);
        }
        else
        {
            Game.MsgPrint($"You drop {oName} ({oPtr.Label}).");
        }

        oPtr.ItemIncrease(-amt);
        oPtr.ItemDescribe();
        oPtr.ItemOptimize();
        Game.HandleStuff();
        if (storeCommandEvent.Store.StoreFactory.UseHomeCarry)
        {
            itemPos = storeCommandEvent.Store.HomeCarry(qPtr);
        }
        else
        {
            itemPos = storeCommandEvent.Store.StoreCarry(qPtr);
        }
        if (itemPos >= 0)
        {
            storeCommandEvent.Store.ScrollToItem(itemPos);
            storeCommandEvent.Store.DisplayInventory();
        }
    }

    private void PurchaseAnalyze(int price, int value, int guess)
    {
        if (value <= 0 && price > value)
        {
            Game.MsgPrint(Game.SingletonRepository.ShopkeeperWorthlessComments.ToWeightedRandom().ChooseOrDefault());
            Game.PlaySound(SoundEffectEnum.StoreSoldWorthless);
        }
        else if (value < guess && price > value)
        {
            Game.MsgPrint(Game.SingletonRepository.ShopkeeperLessThanGuessComments.ToWeightedRandom().ChooseOrDefault());
            Game.PlaySound(SoundEffectEnum.StoreSoldBargain);
        }
        else if (value > guess && value < 4 * guess && price < value)
        {
            Game.MsgPrint(Game.SingletonRepository.ShopkeeperGoodComments.ToWeightedRandom().ChooseOrDefault());
            Game.PlaySound(SoundEffectEnum.StoreSoldCheaply);
        }
        else if (value > guess && price < value)
        {
            Game.MsgPrint(Game.SingletonRepository.ShopkeeperBargainComments.ToWeightedRandom().ChooseOrDefault());
            Game.PlaySound(SoundEffectEnum.StoreSoldExtraCheaply);
        }
    }

    private bool SellHaggle(Store store, Item oPtr, out int price)
    {
        int finalAsk = store.MarkdownItem(oPtr);
        int purse = store.Owner.MaxCost;
        if (finalAsk >= purse)
        {
            Game.MsgPrint("You instantly agree upon the price.");
            Game.MsgPrint(null);
            finalAsk = purse;
        }
        else
        {
            Game.MsgPrint("You quickly agree upon the price.");
            Game.MsgPrint(null);
            finalAsk -= finalAsk / 10;
        }
        const string pmt = "Final Offer";
        finalAsk *= oPtr.Count;
        price = finalAsk;
        string outVal = $"{pmt} :  {finalAsk}";
        Game.Screen.Print(outVal, 1, 0);
        return Game.GetCheck("Accept deal? ");
    }
}
