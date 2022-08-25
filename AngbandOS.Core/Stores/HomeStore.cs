using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.StoreCommands;
using Cthangband.UI;
using System;
using System.Linq;

namespace Cthangband.Stores
{
    [Serializable]
    internal class HomeStore : Store
    {
        public HomeStore(SaveGame saveGame) : base(saveGame, StoreType.StoreHome)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Your home", 0, 100, 99)
        };

        public override string FeatureType => "Home";

        protected override bool StoreWillBuy(Item item)
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

        protected override IStoreCommand AdvertisedStoreCommand1 => new GetStoreCommand();
        protected override IStoreCommand AdvertisedStoreCommand2 => new DropStoreCommand();
        protected override IStoreCommand AdvertisedStoreCommand4 => new RestStoreCommand();
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

        public static HomeStore FindHomeStore(SaveGame saveGame, int town) => (HomeStore)Array.Find(saveGame.Towns[town].Stores, store => store.StoreType == StoreType.StoreHome);

        public void BuyHouse(Player player)
        {
            int price;
            if (player.TownWithHouse == SaveGame.CurTown.Index)
            {
                SaveGame.MsgPrint("You already have the deeds!");
            }
            else
            {
                if (!ServiceHaggle(SaveGame.CurTown.HousePrice, out price))
                {
                    if (price >= player.Gold)
                    {
                        SaveGame.MsgPrint("You do not have the gold!");
                    }
                    else
                    {
                        player.Gold -= price;
                        SayComment_1();
                        SaveGame.PlaySound(SoundEffect.StoreTransaction);
                        StorePrtGold();
                        int oldHouse = player.TownWithHouse;
                        player.TownWithHouse = SaveGame.CurTown.Index;
                        if (oldHouse == -1)
                        {
                            SaveGame.MsgPrint("You may move in at once.");
                        }
                        else
                        {
                            SaveGame.MsgPrint(
                                "I've sold your old house to pay for the removal service.");
                            MoveHouse(SaveGame, oldHouse, player.TownWithHouse);
                        }
                    }
                    SaveGame.HandleStuff();
                }
            }
        }

        private static void MoveHouse(SaveGame saveGame, int oldTown, int newTown)
        {
            Store newStore = FindHomeStore(saveGame, newTown);
            Store oldStore = FindHomeStore(saveGame, oldTown);
            if (oldStore == null)
            {
                return;
            }
            if (newStore == null)
            {
                return;
            }
            oldStore.MoveInventoryToAnotherStore(newStore);
        }
    }
}