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
            new StoreOwner("Magd the Ruthless", 2000, 100, new HumanRace()),
            new StoreOwner("Drako Fairdeal", 4000, 100, new DraconianRace()),
            new StoreOwner("Featherwing", 5000, 100, new SpriteRace()),
            new StoreOwner("Xochinaggua", 10000, 100, new MindFlayerRace()),
            new StoreOwner("Od the Penniless", 2000, 100, new ElfRace()),
            new StoreOwner("Xax", 4000, 100, new GolemRace()),
            new StoreOwner("Jake Small", 5000, 100, new HalfGiantRace()),
            new StoreOwner("Helga the Lost", 10000, 100, new HumanRace()),
            new StoreOwner("Gloom the Phlegmatic", 2000, 100, new ZombieRace()),
            new StoreOwner("Quick-Arm Vollaire", 4000, 100, new VampireRace()),
            new StoreOwner("Asenath", 5000, 100, new ZombieRace()),
            new StoreOwner("Lord Filbert", 10000, 100, new VampireRace()),
            new StoreOwner("Herranyth the Ruthless", 2000, 100, new HumanRace()),
            new StoreOwner("Gagrin Moneylender", 4000, 100, new YeekRace()),
            new StoreOwner("Thrambor the Grubby", 5000, 100, new HalfElfRace()),
            new StoreOwner("Derigrin the Honest", 10000, 100, new HobbitRace()),
            new StoreOwner("Munk the Barterer", 2000, 100, new HalfOgreRace()),
            new StoreOwner("Gadrialdur the Fair", 4000, 100, new HalfElfRace()),
            new StoreOwner("Ninar the Stooped", 5000, 100, new DwarfRace()),
            new StoreOwner("Adirath the Unmagical", 10000, 100, new TchoTchoRace())
        };

        public override string FeatureType => "Pawnbrokers";

        public override bool ItemMatches(Item item)
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
        protected override BaseStoreCommand AdvertisedStoreCommand4 => new IdentifyAllStoreCommand();
        protected override string GetItemDescription(Item oPtr) => oPtr.Description(true, 3);

        protected override bool StoreIdentifiesItems => false;
        protected override bool StoreAnalyzesPurchases => false;
        protected override bool PerformsMaintenanceWhenResting => false;
        protected override int CarryItem(Item qPtr) => HomeCarry(qPtr);
        protected override string BoughtMessage(string oName, int price) => $"You bought back {oName} for {price} gold.";

    }
}
