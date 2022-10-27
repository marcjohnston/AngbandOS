using AngbandOS.Commands;
using AngbandOS.Enumerations;
using AngbandOS.StoreCommands;

namespace AngbandOS.Stores
{
    [Serializable]
    internal class PawnStore : Store
    {
        public PawnStore(SaveGame saveGame) : base(saveGame, StoreType.StorePawn)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Magd the Ruthless", 2000, 100, RaceId.Human),
            new StoreOwner("Drako Fairdeal", 4000, 100, RaceId.Draconian),
            new StoreOwner("Featherwing", 5000, 100, RaceId.Sprite),
            new StoreOwner("Xochinaggua", 10000, 100, RaceId.MindFlayer),
            new StoreOwner("Od the Penniless", 2000, 100, RaceId.Elf), new StoreOwner("Xax", 4000, 100, RaceId.Golem),
            new StoreOwner("Jake Small", 5000, 100, RaceId.HalfGiant),
            new StoreOwner("Helga the Lost", 10000, 100, RaceId.Human),
            new StoreOwner("Gloom the Phlegmatic", 2000, 100, RaceId.Zombie),
            new StoreOwner("Quick-Arm Vollaire", 4000, 100, RaceId.Vampire),
            new StoreOwner("Asenath", 5000, 100, RaceId.Zombie),
            new StoreOwner("Lord Filbert", 10000, 100, RaceId.Vampire),
            new StoreOwner("Herranyth the Ruthless", 2000, 100, RaceId.Human),
            new StoreOwner("Gagrin Moneylender", 4000, 100, RaceId.Yeek),
            new StoreOwner("Thrambor the Grubby", 5000, 100, RaceId.HalfElf),
            new StoreOwner("Derigrin the Honest", 10000, 100, RaceId.Hobbit),
            new StoreOwner("Munk the Barterer", 2000, 100, RaceId.HalfOgre),
            new StoreOwner("Gadrialdur the Fair", 4000, 100, RaceId.HalfElf),
            new StoreOwner("Ninar the Stooped", 5000, 100, RaceId.Dwarf),
            new StoreOwner("Adirath the Unmagical", 10000, 100, RaceId.TchoTcho)
        };

        public override string FeatureType => "Pawnbrokers";

        protected override bool StoreWillBuy(Item item)
        {
            return item.Value() > 0;
        }
        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return null;
        }

        protected override bool MaintainsStockLevels => false;
        public override bool ShufflesOwnersAndPricing => false;
        protected override string BoughtVerb => "pawn";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="price"></param>
        /// <param name="trueToMarkDownFalseToMarkUp"></param>
        /// <returns></returns>
        /// <remarks>
        /// Per Dean Anderson, 7/22/2022
        /// The pawn shop both buys and sells cheaply. The whole idea is that if you need cash you can pawn items
        /// (for less money than you could sell them for), in the knowledge that the shop will hold onto them and then buy
        /// them back later for the amount you pawned them for. If retrieving your items from the pawn shop had a
        /// markup then you'd be better off just selling them  normally and buying new ones to replace them.
        /// </remarks>
        protected override int AdjustPrice(int price, bool trueToMarkDownFalseToMarkUp)
        {
            if (trueToMarkDownFalseToMarkUp == true)
            {
                return price / 3;
            }
            else
            {
                return price / 3;
            }
        }
        protected override IStoreCommand AdvertisedStoreCommand4 => new IdentifyAllStoreCommand();
        protected override string GetItemDescription(Item oPtr) => oPtr.Description(true, 3);

        protected override bool StoreIdentifiesItems => false;
        protected override bool StoreAnalyzesPurchases => false;
        protected override bool PerformsMaintenanceWhenResting => false;
        protected override int CarryItem(Item qPtr) => HomeCarry(qPtr);
        protected virtual string BoughtMessage(string oName, int price) => $"You bought back {oName} for {price} gold.";

    }
}
