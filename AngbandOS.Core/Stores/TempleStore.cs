namespace AngbandOS.Core.Stores
{
    [Serializable]
    internal class TempleStore : Store
    {
        public TempleStore(SaveGame saveGame) : base(saveGame) { }

        public override StoreType StoreType => StoreType.StoreTemple;
        public override string FeatureType => "Temple";
        public override Colour Colour => Colour.Green;
        public override char Character => '4';

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            SaveGame.SingletonRepository.StoreOwners.Get<LudwigTheHumbleStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GunnarThePaladinStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<SirParsivalThePureStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<AsenathTheHolyStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<McKinnonStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<MistressChastityStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<HashnikTheDruidStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FinakStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<KrikkikStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<MorivalTheWildStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<HoshakTheDarkStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<AtalTheWiseStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<IbeniddTheChasteStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<EridishStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<VrudushTheShamanStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<HaobTheBerserkerStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<ProogdishTheYouthfullStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<LumwiseTheMadStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<MuirtTheVirtuousStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<DardobardTheWeakStoreOwner>()
        };

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(HaftedBallAndChain), 2),
                new StockStoreInventoryItem(typeof(HaftedFlail)),
                new StockStoreInventoryItem(typeof(HaftedLeadFilledMace)),
                new StockStoreInventoryItem(typeof(HaftedLucerneHammer)),
                new StockStoreInventoryItem(typeof(HaftedMace), 2),
                new StockStoreInventoryItem(typeof(HaftedMorningStar)),
                new StockStoreInventoryItem(typeof(HaftedQuarterstaff)),
                new StockStoreInventoryItem(typeof(HaftedWarHammer), 2),
                new StockStoreInventoryItem(typeof(HaftedWhip), 2),
                new StockStoreInventoryItem(typeof(CommonPrayerLifeBookItemFactory), 4),
                new StockStoreInventoryItem(typeof(HighMassLifeBookItemFactory), 4),
                new StockStoreInventoryItem(typeof(CureCriticalWoundsPotionItemFactory), 4),
                new StockStoreInventoryItem(typeof(CureLightWoundsPotionItemFactory)),
                new StockStoreInventoryItem(typeof(CureSeriousWoundsPotionItemFactory), 2),
                new StockStoreInventoryItem(typeof(HeroismPotionItemFactory)),
                new StockStoreInventoryItem(typeof(RestoreLifeLevelsPotionItemFactory), 6),
                new StockStoreInventoryItem(typeof(ScrollBlessing)),
                new StockStoreInventoryItem(typeof(ScrollHolyChant)),
                new StockStoreInventoryItem(typeof(ScrollRemoveCurse), 3),
                new StockStoreInventoryItem(typeof(ScrollSpecialRemoveCurse), 2),
                new StockStoreInventoryItem(typeof(ScrollWordOfRecall), 6),
            };
        }

        public override bool ItemMatches(Item item)
        {
            switch (item.Factory)
            {
                case LifeBookItemFactory _:
                case ScrollItemClass _:
                case PotionItemFactory _:
                case HaftedItemClass _:
                    return item.Value() > 0;
                case PolearmItemClass _:
                case SwordItemClass _:
                    item.RefreshFlagBasedProperties();
                    if (item.Characteristics.Blessed)
                        return item.Value() > 0;
                    else
                        return false;
                default:
                    return false;
            }
        }
        protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<RemoveCurseStoreCommand>();
        protected override BaseStoreCommand AdvertisedStoreCommand5 => SaveGame.SingletonRepository.StoreCommands.Get<SacrificeStoreCommand>();
    }
}
