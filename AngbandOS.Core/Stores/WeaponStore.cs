namespace AngbandOS.Stores
{
    [Serializable]
    internal class WeaponStore : Store
    {
        public WeaponStore(SaveGame saveGame) : base(saveGame, StoreType.StoreWeapon)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Arnold the Beastly", 10000, 115, SaveGame.SingletonRepository.Races.Get<TchoTchoRace>()),
            new StoreOwner("Arndal Beast-Slayer", 15000, 110, SaveGame.SingletonRepository.Races.Get<HalfElfRace>()),
            new StoreOwner("Edor the Short", 25000, 115, SaveGame.SingletonRepository.Races.Get<HobbitRace>()),
            new StoreOwner("Oglign Dragon-Slayer", 30000, 112, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Drew the Skilled", 10000, 115, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Orrax Dragonson", 15000, 110, SaveGame.SingletonRepository.Races.Get<DraconianRace>()),
            new StoreOwner("Bob", 25000, 115, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Arkhoth the Stout", 30000, 112, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Sarlyas the Rotten", 10000, 115, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Tuethic Bare-Bones", 15000, 110, SaveGame.SingletonRepository.Races.Get<SkeletonRace>()),
            new StoreOwner("Bilious the Toad", 25000, 115, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Fasgul", 30000, 112, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Ellefris the Paladin", 10000, 115, SaveGame.SingletonRepository.Races.Get<TchoTchoRace>()),
            new StoreOwner("K'trrik'k", 15000, 110, SaveGame.SingletonRepository.Races.Get<KlackonRace>()),
            new StoreOwner("Drocus Spiderfriend", 25000, 115, SaveGame.SingletonRepository.Races.Get<DarkElfRace>()),
            new StoreOwner("Fungus Giant-Slayer", 30000, 112, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Nadoc the Strong", 10000, 115, SaveGame.SingletonRepository.Races.Get<HobbitRace>()),
            new StoreOwner("Eramog the Weak", 15000, 110, SaveGame.SingletonRepository.Races.Get<KoboldRace>()),
            new StoreOwner("Eowilith the Fair", 25000, 115, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Huimog Balrog-Slayer", 30000, 112, SaveGame.SingletonRepository.Races.Get<HalfOrcRace>()),
            new StoreOwner("Peadus the Cruel", 10000, 115, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Vamog Slayer", 15000, 110, SaveGame.SingletonRepository.Races.Get<HalfOgreRace>()),
            new StoreOwner("Hooshnak the Vicious", 25000, 115, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Balenn War-Dancer", 30000, 112, SaveGame.SingletonRepository.Races.Get<TchoTchoRace>())
        };

        public override string FeatureType => "Weaponsmiths";

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(Arrow), 4),
                new StockStoreInventoryItem(typeof(Bolt), 4),
                new StockStoreInventoryItem(typeof(BowLightCrossbow), 2),
                new StockStoreInventoryItem(typeof(BowLong), 2),
                new StockStoreInventoryItem(typeof(BowShort), 2),
                new StockStoreInventoryItem(typeof(BowSling)),
                new StockStoreInventoryItem(typeof(HaftedWhip), 2),
                new StockStoreInventoryItem(typeof(PolearmAwlPike)),
                new StockStoreInventoryItem(typeof(PolearmBattleAxe)),
                new StockStoreInventoryItem(typeof(PolearmBeakedAxe)),
                new StockStoreInventoryItem(typeof(PolearmBroadAxe)),
                new StockStoreInventoryItem(typeof(PolearmLance)),
                new StockStoreInventoryItem(typeof(PolearmPike)),
                new StockStoreInventoryItem(typeof(PolearmSpear)),
                new StockStoreInventoryItem(typeof(PolearmTrident)),
                new StockStoreInventoryItem(typeof(ShotIronShot), 2),
                new StockStoreInventoryItem(typeof(SwordBastardSword)),
                new StockStoreInventoryItem(typeof(SwordBroadSword), 2),
                new StockStoreInventoryItem(typeof(SwordCutlass)),
                new StockStoreInventoryItem(typeof(SwordDagger), 2),
                new StockStoreInventoryItem(typeof(SwordKatana)),
                new StockStoreInventoryItem(typeof(SwordLongSword), 2),
                new StockStoreInventoryItem(typeof(SwordMainGauche), 2),
                new StockStoreInventoryItem(typeof(SwordRapier), 2),
                new StockStoreInventoryItem(typeof(SwordSabre)),
                new StockStoreInventoryItem(typeof(SwordScimitar), 2),
                new StockStoreInventoryItem(typeof(SwordShortSword), 2),
                new StockStoreInventoryItem(typeof(SwordSmallSword), 2),
                new StockStoreInventoryItem(typeof(SwordTulwar)),
            };
        }

        public override bool ItemMatches(Item item)
        {
            switch (item.BaseItemCategory)
            {
                case ShotItemClass _:
                case BoltItemClass _:
                case ArrowItemClass _:
                case BowWeaponItemClass _:
                case DiggingItemClass _:
                case HaftedItemClass _:
                case PolearmItemClass _:
                case SwordItemClass _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<EnchantWeaponStoreCommand>();
    }
}
