using AngbandOS.Commands;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.StoreCommands;
using System;

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
            new StoreOwner("Arnold the Beastly", 10000, 115, RaceId.TchoTcho),
            new StoreOwner("Arndal Beast-Slayer", 15000, 110, RaceId.HalfElf),
            new StoreOwner("Edor the Short", 25000, 115, RaceId.Hobbit),
            new StoreOwner("Oglign Dragon-Slayer", 30000, 112, RaceId.Dwarf),
            new StoreOwner("Drew the Skilled", 10000, 115, RaceId.Human),
            new StoreOwner("Orrax Dragonson", 15000, 110, RaceId.Draconian),
            new StoreOwner("Bob", 25000, 115, RaceId.MiriNigri),
            new StoreOwner("Arkhoth the Stout", 30000, 112, RaceId.Dwarf),
            new StoreOwner("Sarlyas the Rotten", 10000, 115, RaceId.Zombie),
            new StoreOwner("Tuethic Bare-Bones", 15000, 110, RaceId.Skeleton),
            new StoreOwner("Bilious the Toad", 25000, 115, RaceId.MiriNigri),
            new StoreOwner("Fasgul", 30000, 112, RaceId.Zombie),
            new StoreOwner("Ellefris the Paladin", 10000, 115, RaceId.TchoTcho),
            new StoreOwner("K'trrik'k", 15000, 110, RaceId.Klackon),
            new StoreOwner("Drocus Spiderfriend", 25000, 115, RaceId.DarkElf),
            new StoreOwner("Fungus Giant-Slayer", 30000, 112, RaceId.Dwarf),
            new StoreOwner("Nadoc the Strong", 10000, 115, RaceId.Hobbit),
            new StoreOwner("Eramog the Weak", 15000, 110, RaceId.Kobold),
            new StoreOwner("Eowilith the Fair", 25000, 115, RaceId.Vampire),
            new StoreOwner("Huimog Balrog-Slayer", 30000, 112, RaceId.HalfOrc),
            new StoreOwner("Peadus the Cruel", 10000, 115, RaceId.Human),
            new StoreOwner("Vamog Slayer", 15000, 110, RaceId.HalfOgre),
            new StoreOwner("Hooshnak the Vicious", 25000, 115, RaceId.MiriNigri),
            new StoreOwner("Balenn War-Dancer", 30000, 112, RaceId.TchoTcho)
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

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.BaseItemCategory)
            {
                case ShotItemCategory _:
                case BoltItemCategory _:
                case ArrowItemCategory _:
                case BowWeaponItemCategory _:
                case DiggingItemCategory _:
                case HaftedItemCategory _:
                case PolearmItemCategory _:
                case SwordItemCategory _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override IStoreCommand AdvertisedStoreCommand4 => new EnchantWeaponStoreCommand();
    }
}
