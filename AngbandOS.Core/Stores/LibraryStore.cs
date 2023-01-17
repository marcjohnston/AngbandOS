namespace AngbandOS.Stores
{
    [Serializable]
    internal class LibraryStore : Store
    {
        public LibraryStore(SaveGame saveGame) : base(saveGame, StoreType.StoreLibrary)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Randolph Carter", 15000, 108, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Odnar the Sage", 20000, 105, SaveGame.SingletonRepository.Races.Get<HighElfRace>()),
            new StoreOwner("Gandar the Neutral", 25000, 110, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Ro-sha the Patient", 30000, 105, SaveGame.SingletonRepository.Races.Get<GolemRace>()),
            new StoreOwner("Sarai the Swift", 15000, 108, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Bodril the Seer", 20000, 105, SaveGame.SingletonRepository.Races.Get<HighElfRace>()),
            new StoreOwner("Veloin the Quiet", 25000, 110, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Vanthylas the Learned", 30000, 105, SaveGame.SingletonRepository.Races.Get<MindFlayerRace>()),
            new StoreOwner("Ossein the Literate", 15000, 108, SaveGame.SingletonRepository.Races.Get<SkeletonRace>()),
            new StoreOwner("Olvar Bookworm", 20000, 105, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Shallowgrave", 25000, 110, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Death Mask", 30000, 105, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Porcina the Obese", 15000, 108, SaveGame.SingletonRepository.Races.Get<HalfOrcRace>()),
            new StoreOwner("Glaruna Brandybreath", 20000, 105, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Furface Yeek", 25000, 110, SaveGame.SingletonRepository.Races.Get<YeekRace>()),
            new StoreOwner("Bald Oggin", 30000, 105, SaveGame.SingletonRepository.Races.Get<GnomeRace>()),
            new StoreOwner("Asuunu the Learned", 15000, 108, SaveGame.SingletonRepository.Races.Get<MindFlayerRace>()),
            new StoreOwner("Prirand the Dead", 20000, 105, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Ronar the Iron", 25000, 110, SaveGame.SingletonRepository.Races.Get<GolemRace>()),
            new StoreOwner("Galil-Gamir", 30000, 105, SaveGame.SingletonRepository.Races.Get<ElfRace>()),
            new StoreOwner("Rorbag Book-Eater", 15000, 108, SaveGame.SingletonRepository.Races.Get<KoboldRace>()),
            new StoreOwner("Kiriarikirk", 20000, 105, SaveGame.SingletonRepository.Races.Get<KlackonRace>()),
            new StoreOwner("Rilin the Quiet", 25000, 110, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Isung the Lord", 30000, 105, SaveGame.SingletonRepository.Races.Get<HighElfRace>())
        };

        public override string FeatureType => "Bookstore";

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(ChaosBookChaosMastery), 2),
                new StockStoreInventoryItem(typeof(ChaosBookSignofChaos), 2),
                new StockStoreInventoryItem(typeof(CorporealBookBasicChiFlow), 2),
                new StockStoreInventoryItem(typeof(CorporealBookYogicMastery), 2),
                new StockStoreInventoryItem(typeof(DeathBookBlackMass), 4),
                new StockStoreInventoryItem(typeof(DeathBookBlackPrayers), 4),
                new StockStoreInventoryItem(typeof(FolkBookCantripsforBeginners), 2),
                new StockStoreInventoryItem(typeof(FolkBookMagicksofMastery), 2),
                new StockStoreInventoryItem(typeof(FolkBookMajorMagicks), 2),
                new StockStoreInventoryItem(typeof(FolkBookMinorMagicks), 2),
                new StockStoreInventoryItem(typeof(LifeBookBookofCommonPrayer), 4),
                new StockStoreInventoryItem(typeof(LifeBookHighMass), 4),
                new StockStoreInventoryItem(typeof(NatureBookCallOfTheWild), 4),
                new StockStoreInventoryItem(typeof(NatureBookNatureMastery), 4),
                new StockStoreInventoryItem(typeof(SorceryBookBeginnersHandbook), 2),
                new StockStoreInventoryItem(typeof(SorceryBookMasterSorcerersHandbook), 2),
                new StockStoreInventoryItem(typeof(TarotBookCardMastery), 2),
                new StockStoreInventoryItem(typeof(TarotBookConjuringsTricks), 2),
            };
        }

        public override bool ItemMatches(Item item)
        {
            switch (item.BaseItemCategory)
            {
                case SorceryBookItemClass _:
                case NatureBookItemClass _:
                case ChaosBookItemClass _:
                case DeathBookItemClass _:
                case LifeBookItemClass _:
                case TarotBookItemClass _:
                case FolkBookItemClass _:
                case CorporealBookItemClass _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<ResearchSpellStoreCommand>();
    }
}
