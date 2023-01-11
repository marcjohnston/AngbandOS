namespace AngbandOS.Stores
{
    [Serializable]
    internal class GeneralStore : Store
    {
        public GeneralStore(SaveGame saveGame) : base(saveGame, StoreType.StoreGeneral)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Falilmawen the Friendly", 250, 108, SaveGame.SingletonRepository.Races.Get<HobbitRace>()),
            new StoreOwner("Voirin the Cowardly", 500, 108, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Erashnak the Midget", 750, 107, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Grug the Comely", 1000, 107, SaveGame.SingletonRepository.Races.Get<HalfTitanRace>()),
            new StoreOwner("Forovir the Cheap", 250, 108, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Ellis the Fool", 500, 108, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Filbert the Hungry", 750, 107, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Fthnargl Psathiggua", 1000, 107, SaveGame.SingletonRepository.Races.Get<MindFlayerRace>()),
            new StoreOwner("Eloise Long-Dead", 250, 108, SaveGame.SingletonRepository.Races.Get<SpectreRace>()),
            new StoreOwner("Fundi the Slow", 500, 108, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Granthus", 750, 107, SaveGame.SingletonRepository.Races.Get<SkeletonRace>()),
            new StoreOwner("Lorax the Suave", 1000, 107, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Butch", 250, 108, SaveGame.SingletonRepository.Races.Get<HalfOrcRace>()),
            new StoreOwner("Elbereth the Beautiful", 500, 108, SaveGame.SingletonRepository.Races.Get<HighElfRace>()),
            new StoreOwner("Sarleth the Sneaky", 750, 107, SaveGame.SingletonRepository.Races.Get<GnomeRace>()),
            new StoreOwner("Narlock", 1000, 107, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Haneka the Small", 250, 108, SaveGame.SingletonRepository.Races.Get<GnomeRace>()),
            new StoreOwner("Loirin the Mad", 500, 108, SaveGame.SingletonRepository.Races.Get<HalfGiantRace>()),
            new StoreOwner("Wuto Poisonbreath", 750, 107, SaveGame.SingletonRepository.Races.Get<DraconianRace>()),
            new StoreOwner("Araaka the Rotund", 1000, 107, SaveGame.SingletonRepository.Races.Get<DraconianRace>()),
            new StoreOwner("Poogor the Dumb", 250, 108, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Felorfiliand", 500, 108, SaveGame.SingletonRepository.Races.Get<ElfRace>()),
            new StoreOwner("Maroka the Aged", 750, 107, SaveGame.SingletonRepository.Races.Get<GnomeRace>()),
            new StoreOwner("Sasin the Bold", 1000, 107, SaveGame.SingletonRepository.Races.Get<HalfGiantRace>()),
            new StoreOwner("Abiemar the Peasant", 250, 108, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Hurk the Poor", 500, 108, SaveGame.SingletonRepository.Races.Get<HalfOrcRace>()),
            new StoreOwner("Soalin the Wretched", 750, 107, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Merulla the Humble", 1000, 107, SaveGame.SingletonRepository.Races.Get<ElfRace>())
        };

        public override string FeatureType => "GeneralStore";

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(Arrow), 2),
                new StockStoreInventoryItem(typeof(Bolt), 2),
                new StockStoreInventoryItem(typeof(Cloak), 3),
                new StockStoreInventoryItem(typeof(DiggingPick)),
                new StockStoreInventoryItem(typeof(DiggingShovel), 2),
                new StockStoreInventoryItem(typeof(FlaskOfOil), 10),
                new StockStoreInventoryItem(typeof(FoodHardBiscuit)),
                new StockStoreInventoryItem(typeof(FoodPintOfFineAle)),
                new StockStoreInventoryItem(typeof(FoodPintOfFineWine)),
                new StockStoreInventoryItem(typeof(FoodRation), 9),
                new StockStoreInventoryItem(typeof(FoodStripOfVenison), 2),
                new StockStoreInventoryItem(typeof(LightBrassLantern), 4),
                new StockStoreInventoryItem(typeof(LightOrb)),
                new StockStoreInventoryItem(typeof(LightWoodenTorch), 5),
                new StockStoreInventoryItem(typeof(ShotIronShot), 2),
                new StockStoreInventoryItem(typeof(SpikeIronSpike), 2),
            };
        }

        public override bool ItemMatches(Item item)
        {
            switch (item.BaseItemCategory)
            {
                case FoodItemClass _:
                case LightSourceItemClass _:
                case FlaskItemClass _:
                case SpikeItemClass _:
                case ShotItemClass _:
                case ArrowItemClass _:
                case BoltItemClass _:
                case DiggingItemClass _:
                case CloakItemClass _:
                case BottleItemClass _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }

        protected override BaseStoreCommand AdvertisedStoreCommand4 => new HireEscortStoreCommand();
    }
}
