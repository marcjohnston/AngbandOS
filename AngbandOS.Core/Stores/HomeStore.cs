// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class HomeStore : Store
{
    public HomeStore(SaveGame saveGame) : base(saveGame) { }

    public override int MaxInventory => 100;
    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<YourHomeStoreOwner>()
    };

    public override string FeatureType => "Home";
    public override ColourEnum Colour => ColourEnum.Pink;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<AtSymbol>();

    public override bool ItemMatches(Item item)
    {
        return true;
    }

    protected override bool MaintainsStockLevels => false;

    protected override StockStoreInventoryItem[] GetStoreTable()
    {
        return null;
    }
    public override bool ShufflesOwnersAndPricing => false;

    protected override string OwnerName => "";

    protected override string Title => "Your Home";
    protected override StoreInventoryDisplayTypeEnum ShowInventoryDisplayType => StoreInventoryDisplayTypeEnum.InventoryWithoutPrice;
    protected override string SellPrompt => "Drop which item? ";
    protected override bool StoreMaintainsInscription => true;
    protected override string StoreFullMessage => "Your home is full.";
    protected override bool StoreBuysItems => false;
    protected override string NoStockMessage => "Your home is empty.";
    protected override string PurchaseMessage => "Which item do you want to take? ";

    protected override StoreCommand AdvertisedStoreCommand1 => SaveGame.SingletonRepository.StoreCommands.Get<GetStoreCommand>();
    protected override StoreCommand AdvertisedStoreCommand2 => SaveGame.SingletonRepository.StoreCommands.Get<DropStoreCommand>();
    protected override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<RestStoreCommand>();
    protected override string FleeMessage => "Your pack is so full that you flee your home...";

    protected override string GetItemDescription(Item oPtr)
    {
        return oPtr.Description(true, 3);
    }
    protected override int WidthOfDescriptionColumn => 65;
    protected override bool RenderWeightUnitOfMeasurement => true;
    protected override bool StoreCanMergeItem(Item oPtr, Item jPtr)
    {
        return jPtr.CanAbsorb(oPtr);
    }
    protected override bool StoreSellsItems => false;

    protected override bool PerformsMaintenanceWhenResting => false;

    public void BuyHouse()
    {
        int price;
        if (SaveGame.TownWithHouse == SaveGame.CurTown.Index)
        {
            SaveGame.MsgPrint("You already have the deeds!");
        }
        else
        {
            if (!ServiceHaggle(SaveGame.CurTown.HousePrice, out price))
            {
                if (price >= SaveGame.Gold)
                {
                    SaveGame.MsgPrint("You do not have the gold!");
                }
                else
                {
                    SaveGame.Gold -= price;
                    SayComment_1();
                    SaveGame.PlaySound(SoundEffectEnum.StoreTransaction);
                    StorePrtGold();
                    int oldHouse = SaveGame.TownWithHouse;
                    SaveGame.TownWithHouse = SaveGame.CurTown.Index;
                    if (oldHouse == -1)
                    {
                        SaveGame.MsgPrint("You may move in at once.");
                    }
                    else
                    {
                        SaveGame.MsgPrint(
                            "I've sold your old house to pay for the removal service.");
                        SaveGame.MoveHouse(oldHouse, SaveGame.TownWithHouse);
                    }
                }
                SaveGame.HandleStuff();
            }
        }
    }

    /// <summary>
    /// Returns true, if the player doesn't own the home; false, if the player owns the home.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <returns></returns>
    public override bool DoorsLocked(SaveGame saveGame)
    {
        return saveGame.TownWithHouse != saveGame.CurTown.Index;
    }
}