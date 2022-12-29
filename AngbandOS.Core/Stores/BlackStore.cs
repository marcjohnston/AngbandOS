using AngbandOS.Core.Races;

namespace AngbandOS.Stores
{
    [Serializable]
    internal class BlackStore : Store
    {
        public BlackStore(SaveGame saveGame) : base(saveGame, StoreType.StoreBlack)
        {
        }

        public override int MaxInventory => 75;
        public override int StoreMinKeep => 35;
        public override int StoreMaxKeep => 65;
        public override int StoreTurnover => 5;
        public override string FeatureType => "BlackMarket";

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Vhassa the Dead", 20000, 150, new ZombieRace()),
            new StoreOwner("Kyn the Treacherous", 20000, 150, new VampireRace()),
            new StoreOwner("Batrachian Belle", 30000, 150, new MiriNigriRace()),
            new StoreOwner("Corpselight", 30000, 150, new SpectreRace()),
            new StoreOwner("Parrish the Bloodthirsty", 20000, 150, new VampireRace()),
            new StoreOwner("Vile", 20000, 150, new SkeletonRace()),
            new StoreOwner("Prentice the Trusted", 30000, 150, new SkeletonRace()),
            new StoreOwner("Griella Humanslayer", 30000, 150, new ImpRace()),
            new StoreOwner("Charity the Necromancer", 20000, 150, new DarkElfRace()),
            new StoreOwner("Pugnacious the Pugilist", 20000, 150, new HalfOrcRace()),
            new StoreOwner("Footsore the Lucky", 30000, 150, new MiriNigriRace()),
            new StoreOwner("Sidria Lighfingered", 30000, 150, new HumanRace()),
            new StoreOwner("Riatho the Juggler", 20000, 150, new HobbitRace()),
            new StoreOwner("Janaaka the Shifty", 20000, 150, new GnomeRace()),
            new StoreOwner("Cina the Rogue", 30000, 150, new GnomeRace()),
            new StoreOwner("Arunikki Greatclaw", 30000, 150, new DraconianRace()),
            new StoreOwner("Chaeand the Poor", 20000, 150, new HumanRace()),
            new StoreOwner("Afardorf the Brigand", 20000, 150, new TchoTchoRace()),
            new StoreOwner("Lathaxl the Greedy", 30000, 150, new MindFlayerRace()),
            new StoreOwner("Falarewyn", 30000, 150, new SpriteRace())
        };

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return null;
        }

        public override bool ItemMatches(Item item)
        {
            return item.Value() > 0;
        }

        protected override int AdjustPrice(int price, bool trueToMarkDownFalseToMarkUp)
        {
            if (trueToMarkDownFalseToMarkUp == true)
            {
                return price / 2;
            }
            else
            {
                return price * 2;
            }
        }

        protected override Item CreateItem()
        {
            int level;
            level = 35 + Program.Rng.RandomLessThan(35);
            ItemClass itemType = SaveGame.RandomItemType(level, false, false);
            if (itemType == null)
            {
                return null; ;
            }
            Item qPtr = new Item(SaveGame);
            qPtr.AssignItemType(itemType);
            qPtr.ApplyMagic(level, false, false, false);
            return qPtr;
        }
        protected override int MinimumItemValue => 10;
    }
}
