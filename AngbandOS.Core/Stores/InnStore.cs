namespace AngbandOS.Core.Stores
{
    [Serializable]
    internal class InnStore : Store
    {
        private InnStore(SaveGame saveGame) : base(saveGame, StoreType.StoreInn) { } // This object is a singleton

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            SaveGame.SingletonRepository.StoreOwners.Get<MordsanStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FurfootPobberStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<OddoYeeksonStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<DryBonesStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<KleibonsStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<PrendegastStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<StraashaStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<AlliaTheServileStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<LuminTheBlueStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<ShortAlStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<SilentFaldusStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<QuirmbyTheStrangeStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<AldousTheSleepyStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GrundyTheTallStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GobblegutsThunderbreathStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<SilverscaleStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<EtheraaTheFuriousStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<PaetlanTheAlcoholicStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<DrangStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<BarbagTheSlyStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<KirakakStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<NafurTheWoodenStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GrarakTheHospitableStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<LonaTheCharismaticStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<CrediricTheBrewerStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<NydudusTheSlowStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<BaurkTheBusyStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<SevirasTheMindcrafterStoreOwner>()
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
