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
                new StockStoreInventoryItem(typeof(MasteryChaosBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(SignOfChaosChaosBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(BasicChiFlowCorporealBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(YogicMasteryCorporealBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(BlackMassDeathBookItemFactory), 4),
                new StockStoreInventoryItem(typeof(BlackPrayersDeathBookItemFactory), 4),
                new StockStoreInventoryItem(typeof(CantripsforBeginnersFolkBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(MagicksOfMasteryFolkBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(MajorMagicksFolkBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(MinorMagicksFolkBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(CommonPrayerLifeBookItemFactory), 4),
                new StockStoreInventoryItem(typeof(HighMassLifeBookItemFactory), 4),
                new StockStoreInventoryItem(typeof(CallOfTheWildNatureBookItemFactory), 4),
                new StockStoreInventoryItem(typeof(NatureMasteryNatureBookItemFactory), 4),
                new StockStoreInventoryItem(typeof(BeginnersHandbookSorceryBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(MasterSorcerersHandbookSorceryBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(CardMasteryTarotBookItemFactory), 2),
                new StockStoreInventoryItem(typeof(ConjuringsTricksTarotBookItemFactory), 2),
            };
        }

        public override bool ItemMatches(Item item)
        {
            switch (item.Factory)
            {
                case SorceryBookItemFactory _:
                case NatureBookItemFactory _:
                case ChaosBookItemFactory _:
                case DeathBookItemFactory _:
                case LifeBookItemFactory _:
                case TarotBookItemFactory _:
                case FolkBookItemFactory _:
                case CorporealBookItemFactory _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<ResearchSpellStoreCommand>();
    }
}
