using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.ItemCategories;
using Cthangband.StoreCommands;
using System;

namespace Cthangband.Stores
{
    [Serializable]
    internal class MagicStore : Store
    {
        public MagicStore() : base(StoreType.StoreMagic)
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

        protected override ItemIdentifier[] GetStoreTable()
        {
            return new[]
            {
                new ItemIdentifier(typeof(RingProtection)),
                new ItemIdentifier(typeof(RingLevitation)),
                new ItemIdentifier(typeof(RingProtection)),
                new ItemIdentifier(typeof(RingResistFire)),
                new ItemIdentifier(typeof(RingResistCold)),
                new ItemIdentifier(typeof(AmuletCharisma)),
                new ItemIdentifier(typeof(AmuletSlowDigestion)),
                new ItemIdentifier(typeof(AmuletResistAcid)),
                new ItemIdentifier(typeof(AmuletSearching)),
                new ItemIdentifier(typeof(WandSlowMonster)),
                new ItemIdentifier(typeof(WandConfuseMonster)),
                new ItemIdentifier(typeof(WandSleepMonster)),
                new ItemIdentifier(typeof(WandMagicMissile)),
                new ItemIdentifier(typeof(WandStinkingCloud)),
                new ItemIdentifier(typeof(WandWonder)),
                new ItemIdentifier(typeof(WandDisarming)),
                new ItemIdentifier(typeof(StaffLight)),
                new ItemIdentifier(typeof(StaffEnlightenment)),
                new ItemIdentifier(typeof(StaffTrapLocation)),
                new ItemIdentifier(typeof(StaffDoorStairLocation)),
                new ItemIdentifier(typeof(StaffTreasureLocation)),
                new ItemIdentifier(typeof(StaffObjectLocation)),
                new ItemIdentifier(typeof(StaffDetectInvisible)),
                new ItemIdentifier(typeof(StaffDetectEvil)),
                new ItemIdentifier(typeof(LightOrb)),
                new ItemIdentifier(typeof(StaffTeleportation)),
                new ItemIdentifier(typeof(StaffTeleportation)),
                new ItemIdentifier(typeof(StaffTeleportation)),
                new ItemIdentifier(typeof(StaffPerception)),
                new ItemIdentifier(typeof(StaffPerception)),
                new ItemIdentifier(typeof(StaffPerception)),
                new ItemIdentifier(typeof(StaffPerception)),
                new ItemIdentifier(typeof(StaffPerception)),
                new ItemIdentifier(typeof(StaffRemoveCurse)),
                new ItemIdentifier(typeof(StaffCureLightWounds)),
                new ItemIdentifier(typeof(StaffProbing)),
                new ItemIdentifier(typeof(SorceryBookBeginnersHandbook)),
                new ItemIdentifier(typeof(SorceryBookBeginnersHandbook)),
                new ItemIdentifier(typeof(SorceryBookMasterSorcerersHandbook)),
                new ItemIdentifier(typeof(SorceryBookMasterSorcerersHandbook)),
                new ItemIdentifier(typeof(FolkBookCantripsforBeginners)),
                new ItemIdentifier(typeof(FolkBookCantripsforBeginners)), 
                new ItemIdentifier(typeof(FolkBookMinorMagicks)),
                new ItemIdentifier(typeof(FolkBookMinorMagicks)), 
                new ItemIdentifier(typeof(FolkBookMajorMagicks)),
                new ItemIdentifier(typeof(FolkBookMajorMagicks)), 
                new ItemIdentifier(typeof(FolkBookMagicksofMastery)),
                new ItemIdentifier(typeof(FolkBookMagicksofMastery))
            };
        }

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.ItemType.BaseCategory)
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
        protected override IStoreCommand AdvertisedStoreCommand4 => new RestorationStoreCommand();
    }
}
