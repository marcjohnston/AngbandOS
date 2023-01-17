namespace AngbandOS.Stores
{
    [Serializable]
    internal class MagicStore : Store
    {
        public MagicStore(SaveGame saveGame) : base(saveGame, StoreType.StoreMagic)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Skidney the Sorcerer", 15000, 110, SaveGame.SingletonRepository.Races.Get<HalfElfRace>()),
            new StoreOwner("Buggerby the Great", 20000, 113, SaveGame.SingletonRepository.Races.Get<GnomeRace>()),
            new StoreOwner("Kyria the Illusionist", 30000, 110, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Nikki the Necromancer", 30000, 110, SaveGame.SingletonRepository.Races.Get<DarkElfRace>()),
            new StoreOwner("Solostoran", 15000, 110, SaveGame.SingletonRepository.Races.Get<SpriteRace>()),
            new StoreOwner("Achshe the Tentacled", 20000, 113, SaveGame.SingletonRepository.Races.Get<MindFlayerRace>()),
            new StoreOwner("Kaza the Noble", 30000, 110, SaveGame.SingletonRepository.Races.Get<HighElfRace>()),
            new StoreOwner("Fazzil the Dark", 30000, 110, SaveGame.SingletonRepository.Races.Get<DarkElfRace>()),
            new StoreOwner("Angel", 20000, 150, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Flotsam the Bloated", 20000, 150, SaveGame.SingletonRepository.Races.Get<ZombieRace>()),
            new StoreOwner("Nieval", 30000, 150, SaveGame.SingletonRepository.Races.Get<VampireRace>()),
            new StoreOwner("Anastasia the Luminous", 30000, 150, SaveGame.SingletonRepository.Races.Get<SpectreRace>()),
            new StoreOwner("Keldorn the Grand", 15000, 110, SaveGame.SingletonRepository.Races.Get<DwarfRace>()),
            new StoreOwner("Philanthropus", 20000, 113, SaveGame.SingletonRepository.Races.Get<HobbitRace>()),
            new StoreOwner("Agnar the Enchantress", 30000, 110, SaveGame.SingletonRepository.Races.Get<HumanRace>()),
            new StoreOwner("Buliance the Necromancer", 30000, 110, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Vuirak the High-Mage", 15000, 110, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Madish the Smart", 20000, 113, SaveGame.SingletonRepository.Races.Get<MiriNigriRace>()),
            new StoreOwner("Falebrimbor", 30000, 110, SaveGame.SingletonRepository.Races.Get<HighElfRace>()),
            new StoreOwner("Felil-Gand the Subtle", 30000, 110, SaveGame.SingletonRepository.Races.Get<DarkElfRace>()),
            new StoreOwner("Thalegord the Shaman", 15000, 110, SaveGame.SingletonRepository.Races.Get<TchoTchoRace>()),
            new StoreOwner("Cthoaloth the Mystic", 20000, 113, SaveGame.SingletonRepository.Races.Get<MindFlayerRace>()),
            new StoreOwner("Ibeli the Illusionist", 30000, 110, SaveGame.SingletonRepository.Races.Get<SkeletonRace>()),
            new StoreOwner("Heto the Necromancer", 30000, 110, SaveGame.SingletonRepository.Races.Get<YeekRace>())
        };

        public override string FeatureType => "MagicShop";

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(AmuletCharisma)),
                new StockStoreInventoryItem(typeof(AmuletResistAcid)),
                new StockStoreInventoryItem(typeof(AmuletSearching)),
                new StockStoreInventoryItem(typeof(AmuletSlowDigestion)),
                new StockStoreInventoryItem(typeof(FolkBookCantripsforBeginners), 2),
                new StockStoreInventoryItem(typeof(FolkBookMagicksofMastery), 2),
                new StockStoreInventoryItem(typeof(FolkBookMajorMagicks), 2),
                new StockStoreInventoryItem(typeof(FolkBookMinorMagicks), 2),
                new StockStoreInventoryItem(typeof(LightOrb)),
                new StockStoreInventoryItem(typeof(RingLevitation)),
                new StockStoreInventoryItem(typeof(RingProtection), 2),
                new StockStoreInventoryItem(typeof(RingResistCold)),
                new StockStoreInventoryItem(typeof(RingResistFire)),
                new StockStoreInventoryItem(typeof(SorceryBookBeginnersHandbook), 2),
                new StockStoreInventoryItem(typeof(SorceryBookMasterSorcerersHandbook), 2),
                new StockStoreInventoryItem(typeof(StaffCureLightWounds)),
                new StockStoreInventoryItem(typeof(StaffDetectEvil)),
                new StockStoreInventoryItem(typeof(StaffDetectInvisible)),
                new StockStoreInventoryItem(typeof(StaffDoorStairLocation)),
                new StockStoreInventoryItem(typeof(StaffEnlightenment)),
                new StockStoreInventoryItem(typeof(StaffLight)),
                new StockStoreInventoryItem(typeof(StaffObjectLocation)),
                new StockStoreInventoryItem(typeof(StaffPerception), 5),
                new StockStoreInventoryItem(typeof(StaffProbing)),
                new StockStoreInventoryItem(typeof(StaffRemoveCurse)),
                new StockStoreInventoryItem(typeof(StaffTeleportation), 3),
                new StockStoreInventoryItem(typeof(StaffTrapLocation)),
                new StockStoreInventoryItem(typeof(StaffTreasureLocation)),
                new StockStoreInventoryItem(typeof(WandConfuseMonster)),
                new StockStoreInventoryItem(typeof(WandDisarming)),
                new StockStoreInventoryItem(typeof(WandMagicMissile)),
                new StockStoreInventoryItem(typeof(WandSleepMonster)),
                new StockStoreInventoryItem(typeof(WandSlowMonster)),
                new StockStoreInventoryItem(typeof(WandStinkingCloud)),
                new StockStoreInventoryItem(typeof(WandWonder)),
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
                case TarotBookItemClass _:
                case FolkBookItemClass _:
                case CorporealBookItemClass _:
                case AmuletItemClass _:
                case RingItemClass _:
                case StaffItemClass _:
                case WandItemClass _:
                case RodItemClass _:
                case ScrollItemClass _:
                case PotionItemClass _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<ResearchItemStoreCommand>();
    }
}
