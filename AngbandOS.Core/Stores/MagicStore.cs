using AngbandOS.Commands;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.StoreCommands;
using System;

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
            new StoreOwner("Skidney the Sorcerer", 15000, 110, RaceId.HalfElf),
            new StoreOwner("Buggerby the Great", 20000, 113, RaceId.Gnome),
            new StoreOwner("Kyria the Illusionist", 30000, 110, RaceId.Human),
            new StoreOwner("Nikki the Necromancer", 30000, 110, RaceId.DarkElf),
            new StoreOwner("Solostoran", 15000, 110, RaceId.Sprite),
            new StoreOwner("Achshe the Tentacled", 20000, 113, RaceId.MindFlayer),
            new StoreOwner("Kaza the Noble", 30000, 110, RaceId.HighElf),
            new StoreOwner("Fazzil the Dark", 30000, 110, RaceId.DarkElf),
            new StoreOwner("Angel", 20000, 150, RaceId.Vampire),
            new StoreOwner("Flotsam the Bloated", 20000, 150, RaceId.Zombie),
            new StoreOwner("Nieval", 30000, 150, RaceId.Vampire),
            new StoreOwner("Anastasia the Luminous", 30000, 150, RaceId.Spectre),
            new StoreOwner("Keldorn the Grand", 15000, 110, RaceId.Dwarf),
            new StoreOwner("Philanthropus", 20000, 113, RaceId.Hobbit),
            new StoreOwner("Agnar the Enchantress", 30000, 110, RaceId.Human),
            new StoreOwner("Buliance the Necromancer", 30000, 110, RaceId.MiriNigri),
            new StoreOwner("Vuirak the High-Mage", 15000, 110, RaceId.MiriNigri),
            new StoreOwner("Madish the Smart", 20000, 113, RaceId.MiriNigri),
            new StoreOwner("Falebrimbor", 30000, 110, RaceId.HighElf),
            new StoreOwner("Felil-Gand the Subtle", 30000, 110, RaceId.DarkElf),
            new StoreOwner("Thalegord the Shaman", 15000, 110, RaceId.TchoTcho),
            new StoreOwner("Cthoaloth the Mystic", 20000, 113, RaceId.MindFlayer),
            new StoreOwner("Ibeli the Illusionist", 30000, 110, RaceId.Skeleton),
            new StoreOwner("Heto the Necromancer", 30000, 110, RaceId.Yeek)
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
                case SorceryBookItemCategory _:
                case NatureBookItemCategory _:
                case ChaosBookItemCategory _:
                case DeathBookItemCategory _:
                case TarotBookItemCategory _:
                case FolkBookItemCategory _:
                case CorporealBookItemCategory _:
                case AmuletItemCategory _:
                case RingItemCategory _:
                case StaffItemCategory _:
                case WandItemCategory _:
                case RodItemCategory _:
                case ScrollItemCategory _:
                case PotionItemCategory _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override IStoreCommand AdvertisedStoreCommand4 => new ResearchItemStoreCommand();
    }
}
