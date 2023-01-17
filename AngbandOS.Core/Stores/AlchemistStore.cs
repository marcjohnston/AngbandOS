namespace AngbandOS.Stores
{
    [Serializable]
    internal class AlchemistStore : Store
    {
        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Mauser the Chemist", 10000, 111, SaveGame.SingletonRepository.Races.Get<HalfElfRace>()),
            new StoreOwner("Wizzle the Chaotic", 10000, 110, SaveGame.SingletonRepository.Races.Get<HobbitRace>()),
            new StoreOwner("Kakalrakakal", 15000, 116, SaveGame.SingletonRepository.Races.Get<KlackonRace>()),
            new StoreOwner("Jal-Eth the Alchemist", 15000, 111, SaveGame.SingletonRepository.Races.Get<ElfRace>()),
            new StoreOwner("Fanelath the Cautious", 10000, 111, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Runcie the Insane", 10000, 110, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Grumbleworth", 15000, 116, SaveGame.SingletonRepository.Races.Get<GnomeRace>()),
            new StoreOwner("Flitter", 15000, 111, SaveGame.SingletonRepository.Races.Get<SpriteRace>()),
            new StoreOwner("Xarillus", 10000, 111, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Egbert the Old", 10000, 110, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Valindra the Proud", 15000, 116, SaveGame.SingletonRepository.Races.Get<HighElfRace>()),
            new StoreOwner("Taen the Alchemist", 15000, 111, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Cayd the Sweet", 10000, 111, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Fulir the Dark", 10000, 110, SaveGame.SingletonRepository.Races.Get<NibelungRace>()),
            new StoreOwner("Domli the Humble", 15000, 116, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Yaarjukka Demonspawn", 15000, 111, SaveGame.SingletonRepository.Races.Get<ImpRace>()),
            new StoreOwner("Gelaraldor the Herbmaster", 10000, 111, SaveGame.SingletonRepository.Races.Get<HighElfRace>()),
            new StoreOwner("Olelaldan the Wise", 10000, 110, SaveGame.SingletonRepository.Races.Get<TchoTchoRace>()),
            new StoreOwner("Fthoglo the Demonicist", 15000, 116, SaveGame.SingletonRepository.Races.Get<ImpRace>()),
            new StoreOwner("Dridash the Alchemist", 15000, 111, SaveGame.SingletonRepository.Races.Get<HalfOrcRace>())
        };

        public AlchemistStore(SaveGame saveGame) : base(saveGame, StoreType.StoreAlchemist)
        {
        }

        public override string FeatureType => "Alchemist";

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(PotionRestoreCharisma), 2),
                new StockStoreInventoryItem(typeof(PotionRestoreConstitution), 2),
                new StockStoreInventoryItem(typeof(PotionRestoreDexterity), 2),
                new StockStoreInventoryItem(typeof(PotionRestoreIntelligence), 2),
                new StockStoreInventoryItem(typeof(PotionRestoreStrength), 2),
                new StockStoreInventoryItem(typeof(PotionRestoreWisdom), 2),
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
            switch (item.BaseItemCategory)
            {
                case ScrollItemClass _:
                case PotionItemClass _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<RestorationStoreCommand>();
    }
}
