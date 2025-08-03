// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SellScript : Script, IStoreCommandScript
{
    private SellScript(Game game) : base(game) { }

    public virtual string[] ShopkeeperBargainComments => new string[]
    {
        "Yipee!",
        "I think I'll retire!",
        "The shopkeeper jumps for joy.",
        "The shopkeeper smiles gleefully."
    };

    public virtual string[] ShopkeeperGoodComments => new string[]
    {
        "Cool!",
        "You've made my day!",
        "The shopkeeper giggles.",
        "The shopkeeper laughs loudly."
    };

    public virtual string[] ShopkeeperLessThanGuessComments => new string[]
    {
        "Damn!",
        "You bastard!",
        "The shopkeeper curses at you.",
        "The shopkeeper glares at you."
    };

    public virtual string[] ShopkeeperWorthlessComments => new string[]
    {
        "Arrgghh!",
        "You bastard!",
        "You hear someone sobbing...",
        "The shopkeeper howls in agony!"
    };      

    /// <summary>
    /// Allows an item to be sold to the store.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
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

        if (oPtr.IsInEquipment && oPtr.EffectivePropertySet.IsCursed)
        {
            Game.MsgPrint("Hmmm, it seems to be cursed.");
            return;
        }
        int amt = 1;
        if (oPtr.StackCount > 1)
        {
            amt = Game.GetQuantity(oPtr.StackCount, true);
            if (amt <= 0)
            {
                return;
            }
        }
        Item qPtr = oPtr.Clone();
        qPtr.StackCount = amt;
        string oName = qPtr.GetFullDescription(true);
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
            Game.Gold.IntValue += price;
            Game.StorePrtGold();
            int guess = qPtr.Value() * qPtr.StackCount;
            if (storeCommandEvent.Store.StoreFactory.StoreIdentifiesItems)
            {
                oPtr.IsFlavorAware = true;
                oPtr.BecomeKnown();
            }
            Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
            qPtr = oPtr.Clone();
            qPtr.StackCount = amt;
            int value;
            if (!storeCommandEvent.Store.StoreFactory.StoreAnalyzesPurchases)
            {
                value = guess;
            }
            else
            {
                value = qPtr.Value() * qPtr.StackCount;
                oName = qPtr.GetFullDescription(true);
            }
            Game.MsgPrint($"You {storeCommandEvent.Store.StoreFactory.BoughtVerb} {oName} for {price} gold.");
            PurchaseAnalyze(price, value, guess);
        }
        else
        {
            Game.MsgPrint($"You drop {oName} ({oPtr.Label}).");
        }

        oPtr.ModifyStackCount(-amt);
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
            Game.MsgPrint(new WeightedRandom<string>(Game, ShopkeeperWorthlessComments).ChooseOrDefault());
            Game.PlaySound(SoundEffectEnum.StoreSoldWorthless);
        }
        else if (value < guess && price > value)
        {
            Game.MsgPrint(new WeightedRandom<string>(Game, ShopkeeperLessThanGuessComments).ChooseOrDefault());
            Game.PlaySound(SoundEffectEnum.StoreSoldBargain);
        }
        else if (value > guess && value < 4 * guess && price < value)
        {
            Game.MsgPrint(new WeightedRandom<string>(Game, ShopkeeperGoodComments).ChooseOrDefault());
            Game.PlaySound(SoundEffectEnum.StoreSoldCheaply);
        }
        else if (value > guess && price < value)
        {
            Game.MsgPrint(new WeightedRandom<string>(Game, ShopkeeperBargainComments).ChooseOrDefault());
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
        finalAsk *= oPtr.StackCount;
        price = finalAsk;
        string outVal = $"{pmt} :  {finalAsk}";
        Game.Screen.Print(outVal, 1, 0);
        return Game.GetCheck("Accept deal? ");
    }
}
