namespace AngbandOS.Core.Stores
{
    [Serializable]
    internal class GeneralStore : Store
    {
        public GeneralStore(SaveGame saveGame) : base(saveGame) { }
        public override StoreType StoreType => StoreType.StoreGeneral;

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            SaveGame.SingletonRepository.StoreOwners.Get<FalilmawenTheFriendlyStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<VoirinTheCowardlyStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<ErashnakTheMidgetStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GrugTheComelyStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<ForovirTheCheapStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<EllisTheFoolStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FilbertTheHungryStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FthnarglPsathigguaStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<EloiseLongDeadStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FundiTheSlowStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GranthusStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<LoraxTheSuaveStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<ButchStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<ElberethTheBeautifulStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<SarlethTheSneakyStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<NarlockStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<HanekaTheSmallStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<LoirinTheMadStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<WutoPoisonbreathStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<AraakaTheRotundStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<PoogorTheDumbStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FelorfiliandStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<MarokaTheAgedStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<SasinTheBoldStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<AbiemarThePeasantStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<HurkThePoorStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<SoalinTheWretchedStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<MerullaTheHumbleStoreOwner>()
        };

        public override string FeatureType => "GeneralStore";
        public override Colour Colour => Colour.BrightBrown;
        public override char Character => '1';
        public override string Description => "General Store";

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

        protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<HireEscortStoreCommand>();
    }
}
