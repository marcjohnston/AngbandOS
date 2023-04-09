namespace AngbandOS.Core.Stores
{
    [Serializable]
    internal class LibraryStore : Store
    {
        public LibraryStore(SaveGame saveGame) : base(saveGame) { }

        public override StoreType StoreType => StoreType.StoreLibrary;
        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            SaveGame.SingletonRepository.StoreOwners.Get<RandolphCarterStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<OdnarTheSageStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GandarTheNeutralStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<RoshaThePatientStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<SaraiTheSwiftStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<BodrilTheSeerStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<VeloinTheQuietStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<VanthylasTheLearnedStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<OsseinTheLiterateStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<OlvarBookwormStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<ShallowgraveStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<DeathMaskStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<PorcinaTheObeseStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GlarunaBrandybreathStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FurfaceYeekStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<BaldOgginStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<AsuunuTheLearnedStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<PrirandTheDeadStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<RonarTheIronStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GalilGamirStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<RorbagBookEaterStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<KiriarikirkStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<RilinTheQuietStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<IsungTheLordStoreOwner>()
        };

        public override string FeatureType => "Bookstore";
        public override Colour Colour => Colour.Orange;
        public override char Character => '9';

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
            switch (item.Factory)
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
