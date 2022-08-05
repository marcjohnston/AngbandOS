using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.ItemCategories;
using Cthangband.StoreCommands;
using System;

namespace Cthangband.Stores
{
    [Serializable]
    internal class WeaponStore : Store
    {
        public WeaponStore() : base(StoreType.StoreWeapon)
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

        protected override ItemIdentifier[] GetStoreTable()
        {
            return new[]
            {
                new ItemIdentifier(typeof(SwordDagger)),
                new ItemIdentifier(typeof(SwordMainGauche)),
                new ItemIdentifier(typeof(SwordRapier)),
                new ItemIdentifier(typeof(SwordSmallSword)),
                new ItemIdentifier(typeof(SwordShortSword)),
                new ItemIdentifier(typeof(SwordSabre)),
                new ItemIdentifier(typeof(SwordCutlass)),
                new ItemIdentifier(typeof(SwordTulwar)),
                new ItemIdentifier(typeof(SwordBroadSword)),
                new ItemIdentifier(typeof(SwordLongSword)),
                new ItemIdentifier(typeof(SwordScimitar)),
                new ItemIdentifier(typeof(SwordKatana)),
                new ItemIdentifier(typeof(SwordBastardSword)),
                new ItemIdentifier(typeof(PolearmSpear)),
                new ItemIdentifier(typeof(PolearmAwlPike)),
                new ItemIdentifier(typeof(PolearmTrident)),
                new ItemIdentifier(typeof(PolearmPike)),
                new ItemIdentifier(typeof(PolearmBeakedAxe)),
                new ItemIdentifier(typeof(PolearmBroadAxe)),
                new ItemIdentifier(typeof(PolearmLance)),
                new ItemIdentifier(typeof(PolearmBattleAxe)),
                new ItemIdentifier(typeof(HaftedWhip)),
                new ItemIdentifier(typeof(BowSling)),
                new ItemIdentifier(typeof(BowShort)),
                new ItemIdentifier(typeof(BowLong)),
                new ItemIdentifier(typeof(BowLightCrossbow)),
                new ItemIdentifier(typeof(ShotIronShot)),
                new ItemIdentifier(typeof(ShotIronShot)),
                new ItemIdentifier(typeof(Arrow)),
                new ItemIdentifier(typeof(Arrow)),
                new ItemIdentifier(typeof(Bolt)),
                new ItemIdentifier(typeof(Bolt)),
                new ItemIdentifier(typeof(BowLong)),
                new ItemIdentifier(typeof(BowLightCrossbow)),
                new ItemIdentifier(typeof(Arrow)),
                new ItemIdentifier(typeof(Arrow)),
                new ItemIdentifier(typeof(Bolt)),
                new ItemIdentifier(typeof(Bolt)),
                new ItemIdentifier(typeof(BowShort)),
                new ItemIdentifier(typeof(SwordDagger)),
                new ItemIdentifier(typeof(SwordMainGauche)),
                new ItemIdentifier(typeof(SwordRapier)),
                new ItemIdentifier(typeof(SwordSmallSword)),
                new ItemIdentifier(typeof(SwordShortSword)),
                new ItemIdentifier(typeof(HaftedWhip)),
                new ItemIdentifier(typeof(SwordBroadSword)),
                new ItemIdentifier(typeof(SwordLongSword)),
                new ItemIdentifier(typeof(SwordScimitar))
            };
        }

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.ItemType.BaseCategory)
            {
                case ShotItemCategory _:
                case BoltItemCategory _:
                case ArrowItemCategory _:
                case BowItemCategory _:
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
