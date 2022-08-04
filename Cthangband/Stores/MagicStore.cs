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
                new ItemIdentifier(ItemCategory.Ring, RingType.Protection),
                new ItemIdentifier(ItemCategory.Ring, RingType.FeatherFall),
                new ItemIdentifier(ItemCategory.Ring, RingType.Protection),
                new ItemIdentifier(ItemCategory.Ring, RingType.ResistFire),
                new ItemIdentifier(ItemCategory.Ring, RingType.ResistCold),
                new ItemIdentifier(ItemCategory.Amulet, AmuletType.Charisma),
                new ItemIdentifier(ItemCategory.Amulet, AmuletType.SlowDigest),
                new ItemIdentifier(ItemCategory.Amulet, AmuletType.ResistAcid),
                new ItemIdentifier(ItemCategory.Amulet, AmuletType.Searching),
                new ItemIdentifier(ItemCategory.Wand, WandType.SlowMonster),
                new ItemIdentifier(ItemCategory.Wand, WandType.ConfuseMonster),
                new ItemIdentifier(ItemCategory.Wand, WandType.SleepMonster),
                new ItemIdentifier(ItemCategory.Wand, WandType.MagicMissile),
                new ItemIdentifier(ItemCategory.Wand, WandType.StinkingCloud),
                new ItemIdentifier(ItemCategory.Wand, WandType.Wonder),
                new ItemIdentifier(ItemCategory.Wand, WandType.Disarming),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Light),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Mapping),
                new ItemIdentifier(ItemCategory.Staff, StaffType.DetectTrap),
                new ItemIdentifier(ItemCategory.Staff, StaffType.DetectDoor),
                new ItemIdentifier(ItemCategory.Staff, StaffType.DetectGold),
                new ItemIdentifier(ItemCategory.Staff, StaffType.DetectItem),
                new ItemIdentifier(ItemCategory.Staff, StaffType.DetectInvis),
                new ItemIdentifier(ItemCategory.Staff, StaffType.DetectEvil),
                new ItemIdentifier(ItemCategory.Light, LightType.Orb),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Teleportation),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Teleportation),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Teleportation),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Identify),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Identify),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Identify),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Identify),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Identify),
                new ItemIdentifier(ItemCategory.Staff, StaffType.RemoveCurse),
                new ItemIdentifier(ItemCategory.Staff, StaffType.CureLight),
                new ItemIdentifier(ItemCategory.Staff, StaffType.Probing),
                new ItemIdentifier(ItemCategory.SorceryBook, 0),
                new ItemIdentifier(ItemCategory.SorceryBook, 0),
                new ItemIdentifier(ItemCategory.SorceryBook, 1),
                new ItemIdentifier(ItemCategory.SorceryBook, 1), new ItemIdentifier(ItemCategory.FolkBook, 0),
                new ItemIdentifier(ItemCategory.FolkBook, 0), new ItemIdentifier(ItemCategory.FolkBook, 1),
                new ItemIdentifier(ItemCategory.FolkBook, 1), new ItemIdentifier(ItemCategory.FolkBook, 2),
                new ItemIdentifier(ItemCategory.FolkBook, 2), new ItemIdentifier(ItemCategory.FolkBook, 3),
                new ItemIdentifier(ItemCategory.FolkBook, 3)
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
