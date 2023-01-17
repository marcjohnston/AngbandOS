namespace AngbandOS.Stores
{
    [Serializable]
    internal class ArmouryStore : Store
    {
        public ArmouryStore(SaveGame saveGame) : base(saveGame, StoreType.StoreArmoury)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Kon-Dar the Ugly", 10000, 115, SaveGame.SingletonRepository.Races.Get<HalfOrcRace>()),
            new StoreOwner("Darg-Low the Grim", 15000, 111, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Decado the Handsome", 25000, 112, SaveGame.SingletonRepository.Races.Get<GreatOneRace>()),
            new StoreOwner("Elo Dragonscale", 30000, 112, SaveGame.SingletonRepository.Races.Get<ElfRace>()),
            new StoreOwner("Delicatus", 10000, 115, SaveGame.SingletonRepository.Races.Get<SpriteRace>()),
            new StoreOwner("Gruce the Huge", 15000, 111, SaveGame.SingletonRepository.Races.Get<HalfGiantRace>()),
            new StoreOwner("Animus", 25000, 112, SaveGame.SingletonRepository.Races.Get<GolemRace>()),
            new StoreOwner("Malvus", 30000, 112, SaveGame.SingletonRepository.Races.Get<HalfTitanRace>()),
            new StoreOwner("Selaxis", 10000, 115, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Deathchill", 15000, 111, SaveGame.SingletonRepository.Races.Get<SpectreRace>()),
            new StoreOwner("Drios the Faint", 25000, 112, SaveGame.SingletonRepository.Races.Get<SpectreRace>()),
            new StoreOwner("Bathric the Cold", 30000, 112, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Vengella the Cruel", 10000, 115, SaveGame.SingletonRepository.Races.Get<HalfTrollRace>()),
            new StoreOwner("Wyrana the Mighty", 15000, 111, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Yojo II", 25000, 112, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Ranalar the Sweet", 30000, 112, SaveGame.SingletonRepository.Races.Get<GreatOneRace>()),
            new StoreOwner("Horbag the Unclean", 10000, 115, SaveGame.SingletonRepository.Races.Get<HalfOrcRace>()),
            new StoreOwner("Elelen the Telepath", 15000, 111, SaveGame.SingletonRepository.Races.Get<DarkElfRace>()),
            new StoreOwner("Isedrelias", 25000, 112, SaveGame.SingletonRepository.Races.Get<SpriteRace>()),
            new StoreOwner("Vegnar One-eye", 30000, 112, SaveGame.SingletonRepository.Races.Get<CyclopsRace>()),
            new StoreOwner("Rodish the Chaotic", 10000, 115, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Hesin Swordmaster", 15000, 111, SaveGame.SingletonRepository.Races.Get<NibelungRace>()),
            new StoreOwner("Elvererith the Cheat", 25000, 112, SaveGame.SingletonRepository.Races.Get<DarkElfRace>()),
            new StoreOwner("Zzathath the Imp", 30000, 112, SaveGame.SingletonRepository.Races.Get<ImpRace>())
        };

        public override string FeatureType => "Armoury";

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(BootsHardLeatherBoots), 4),
                new StockStoreInventoryItem(typeof(BootsSoftLeatherBoots), 2),
                new StockStoreInventoryItem(typeof(GlovesSetOfGauntlets), 2),
                new StockStoreInventoryItem(typeof(GlovesSetOfLeatherGloves), 3),
                new StockStoreInventoryItem(typeof(HardArmorAugmentedChainMail)),
                new StockStoreInventoryItem(typeof(HardArmorBarChainMail)),
                new StockStoreInventoryItem(typeof(HardArmorChainMail), 4),
                new StockStoreInventoryItem(typeof(HardArmorDoubleChainMail)),
                new StockStoreInventoryItem(typeof(HardArmorMetalBrigandineArmour)),
                new StockStoreInventoryItem(typeof(HardArmorMetalScaleMail), 2),
                new StockStoreInventoryItem(typeof(HelmHardLeatherCap), 4),
                new StockStoreInventoryItem(typeof(HelmIronHelm)),
                new StockStoreInventoryItem(typeof(HelmMetalCap)),
                new StockStoreInventoryItem(typeof(ShieldLargeLeatherShield)),
                new StockStoreInventoryItem(typeof(ShieldSmallLeatherShield), 4),
                new StockStoreInventoryItem(typeof(ShieldSmallMetalShield)),
                new StockStoreInventoryItem(typeof(SoftArmorHardLeatherArmour), 3),
                new StockStoreInventoryItem(typeof(SoftArmorHardStuddedLeather), 2),
                new StockStoreInventoryItem(typeof(SoftArmorLeatherScaleMail), 3),
                new StockStoreInventoryItem(typeof(SoftArmorRobe), 3),
                new StockStoreInventoryItem(typeof(SoftArmorSoftLeatherArmour), 4),
            };
        }

        public override bool ItemMatches(Item item)
        {
            switch (item.BaseItemCategory)
            {
                case BootsItemClass _:
                case GlovesItemClass _:
                case CrownItemClass _:
                case HelmItemClass _:
                case ShieldItemClass _:
                case CloakItemClass _:
                case SoftArmorItemClass _:
                case HardArmorItemClass _:
                case DragArmorItemClass _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<EnchantArmorStoreCommand>();
    }
}
