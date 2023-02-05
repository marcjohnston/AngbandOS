namespace AngbandOS.Core.Stores
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
            new StoreOwner("Vhassa the Dead", 20000, 150, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Kyn the Treacherous", 20000, 150, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Batrachian Belle", 30000, 150, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Corpselight", 30000, 150, SaveGame.SingletonRepository.Races.Get<SpectreRace>()),
            new StoreOwner("Parrish the Bloodthirsty", 20000, 150, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Vile", 20000, 150, SaveGame.SingletonRepository.Races.Get<SkeletonRace>()),
            new StoreOwner("Prentice the Trusted", 30000, 150, SaveGame.SingletonRepository.Races.Get<SkeletonRace>()),
            new StoreOwner("Griella Humanslayer", 30000, 150, SaveGame.SingletonRepository.Races.Get<ImpRace>()),
            new StoreOwner("Charity the Necromancer", 20000, 150, SaveGame.SingletonRepository.Races.Get<DarkElfRace>()),
            new StoreOwner("Pugnacious the Pugilist", 20000, 150, SaveGame.SingletonRepository.Races.Get<HalfOrcRace>()),
            new StoreOwner("Footsore the Lucky", 30000, 150, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Sidria Lighfingered", 30000, 150, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Riatho the Juggler", 20000, 150, SaveGame.SingletonRepository.Races.Get<HobbitRace>()),
            new StoreOwner("Janaaka the Shifty", 20000, 150, SaveGame.SingletonRepository.Races.Get<GnomeRace>()),
            new StoreOwner("Cina the Rogue", 30000, 150, SaveGame.SingletonRepository.Races.Get<GnomeRace>()),
            new StoreOwner("Arunikki Greatclaw", 30000, 150, SaveGame.SingletonRepository.Races.Get<DraconianRace>()),
            new StoreOwner("Chaeand the Poor", 20000, 150, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Afardorf the Brigand", 20000, 150, SaveGame.SingletonRepository.Races.Get<TchoTchoRace>()),
            new StoreOwner("Lathaxl the Greedy", 30000, 150, SaveGame.SingletonRepository.Races.Get<MindFlayerRace>()),
            new StoreOwner("Falarewyn", 30000, 150, SaveGame.SingletonRepository.Races.Get<SpriteRace>())
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
