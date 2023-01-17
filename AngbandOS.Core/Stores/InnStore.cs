namespace AngbandOS.Stores
{
    [Serializable]
    internal class InnStore : Store
    {
        public InnStore(SaveGame saveGame) : base(saveGame, StoreType.StoreInn)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Mordsan", 15000, 108, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Furfoot Pobber", 20000, 105, SaveGame.SingletonRepository.Races.Get<HobbitRace>()),
            new StoreOwner("Oddo Yeekson", 25000, 110, SaveGame.SingletonRepository.Races.Get<YeekRace>()),
            new StoreOwner("Dry-Bones", 30000, 105, SaveGame.SingletonRepository.Races.Get<SkeletonRace>()),
            new StoreOwner("Kleibons", 15000, 108, SaveGame.SingletonRepository.Races.Get<KlackonRace>()),
            new StoreOwner("Prendegast", 20000, 105, SaveGame.SingletonRepository.Races.Get<HobbitRace>()),
            new StoreOwner("Straasha", 25000, 110, SaveGame.SingletonRepository.Races.Get<DraconianRace>()),
            new StoreOwner("Allia the Servile", 30000, 105, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Lumin the Blue", 15000, 108, SaveGame.SingletonRepository.Races.Get<SpectreRace>()),
            new StoreOwner("Short Al", 20000, 105, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Silent Faldus", 25000, 110, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Quirmby the Strange", 30000, 105, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Aldous the Sleepy", 15000, 108, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Grundy the Tall", 20000, 105, SaveGame.SingletonRepository.Races.Get<HobbitRace>()),
            new StoreOwner("Gobbleguts Thunderbreath", 25000, 110, SaveGame.SingletonRepository.Races.Get<HalfTrollRace>()),
            new StoreOwner("Silverscale", 30000, 105, SaveGame.SingletonRepository.Races.Get<DraconianRace>()),
            new StoreOwner("Etheraa the Furious", 15000, 108, SaveGame.SingletonRepository.Races.Get<TchoTchoRace>()),
            new StoreOwner("Paetlan the Alcoholic", 20000, 105, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Drang", 25000, 110, SaveGame.SingletonRepository.Races.Get<HalfOgreRace>()),
            new StoreOwner("Barbag the Sly", 30000, 105, SaveGame.SingletonRepository.Races.Get<KoboldRace>()),
            new StoreOwner("Kirakak", 15000, 108, SaveGame.SingletonRepository.Races.Get<KlackonRace>()),
            new StoreOwner("Nafur the Wooden", 20000, 105, SaveGame.SingletonRepository.Races.Get<GolemRace>()),
            new StoreOwner("Grarak the Hospitable", 25000, 110, SaveGame.SingletonRepository.Races.Get<HalfGiantRace>()),
            new StoreOwner("Lona the Charismatic", 30000, 105, SaveGame.SingletonRepository.Races.Get<GnomeRace>()),
            new StoreOwner("Crediric the Brewer", 15000, 108, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Nydudus the Slow", 20000, 105, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Baurk the Busy", 25000, 110, SaveGame.SingletonRepository.Races.Get<YeekRace>()),
            new StoreOwner("Seviras the Mindcrafter", 30000, 105, SaveGame.SingletonRepository.Races.Get<HumanRace>())
        };

        public override string FeatureType => "Inn";

        public override bool ItemMatches(Item item)
        {
            return false;
        }

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(FoodHardBiscuit), 2),
                new StockStoreInventoryItem(typeof(FoodPintOfFineAle), 10),
                new StockStoreInventoryItem(typeof(FoodPintOfFineWine), 10),
                new StockStoreInventoryItem(typeof(FoodRation), 18),
                new StockStoreInventoryItem(typeof(FoodStripOfVenison), 4),
                new StockStoreInventoryItem(typeof(ScrollSatisfyHunger), 4),
            };
        }

        public override int StoreMaxKeep => 4;
        protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<HireRoomStoreCommand>();
        protected override bool PerformsMaintenanceWhenResting => false;
    }
}
