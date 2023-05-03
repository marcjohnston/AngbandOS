namespace AngbandOS.Core.Stores
{
    [Serializable]
    internal class AlchemistStore : Store
    {
        public AlchemistStore(SaveGame saveGame) : base(saveGame) { }

        public override StoreType StoreType => StoreType.StoreAlchemist;
        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            SaveGame.SingletonRepository.StoreOwners.Get<MauserTheChemistStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<WizzleTheChaoticStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<KakalrakakalStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<JalEthTheAlchemistStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FanelathTheCautiousStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<RuncieTheInsaneStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GrumbleworthStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FlitterStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<XarillusStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<EgbertTheOldStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<ValindraTheProudStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<TaenTheAlchemistStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<CaydTheSweetStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FulirTheDarkStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<DomliTheHumbleStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<YaarjukkaDemonspawnStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<GelaraldorTheHerbmasterStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<OlelaldanTheWiseStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<FthogloTheDemonicistStoreOwner>(),
            SaveGame.SingletonRepository.StoreOwners.Get<DridashTheAlchemistStoreOwner>()
        };

        public override string FeatureType => "Alchemist";
        public override Colour Colour => Colour.Blue;
        public override char Character => '5';
        public override string Description => "Alchemy Shop";

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(RestoreCharismaPotionItemFactory), 2),
                new StockStoreInventoryItem(typeof(RestoreConstitutionPotionItemFactory), 2),
                new StockStoreInventoryItem(typeof(RestoreDexterityPotionItemFactory), 2),
                new StockStoreInventoryItem(typeof(RestoreIntelligencePotionItemFactory), 2),
                new StockStoreInventoryItem(typeof(RestoreStrengthPotionItemFactory), 2),
                new StockStoreInventoryItem(typeof(RestoreWisdomPotionItemFactory), 2),
                new StockStoreInventoryItem(typeof(ScrollDetectInvisible)),
                new StockStoreInventoryItem(typeof(ScrollEnchantArmor), 3),
                new StockStoreInventoryItem(typeof(ScrollEnchantWeaponToDam)),
                new StockStoreInventoryItem(typeof(ScrollEnchantWeaponToHit)),
                new StockStoreInventoryItem(typeof(ScrollIdentify), 6),
                new StockStoreInventoryItem(typeof(ScrollLight), 2),
                new StockStoreInventoryItem(typeof(ScrollMagicMapping)),
                new StockStoreInventoryItem(typeof(ScrollMonsterConfusion)),
                new StockStoreInventoryItem(typeof(ScrollObjectDetection)),
                new StockStoreInventoryItem(typeof(ScrollPhaseDoor), 2),
                new StockStoreInventoryItem(typeof(ScrollRecharging), 2),
                new StockStoreInventoryItem(typeof(ScrollSatisfyHunger), 4),
                new StockStoreInventoryItem(typeof(ScrollSpecialIdentify), 2),
                new StockStoreInventoryItem(typeof(ScrollTeleportation), 3),
                new StockStoreInventoryItem(typeof(ScrollTrapDetection)),
                new StockStoreInventoryItem(typeof(ScrollTreasureDetection)),
                new StockStoreInventoryItem(typeof(ScrollWordOfRecall), 4),
            };
        }

        public override bool ItemMatches(Item item)
        {
            switch (item.Factory)
            {
                case ScrollItemClass _:
                case PotionItemFactory _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<RestorationStoreCommand>();
    }
}
