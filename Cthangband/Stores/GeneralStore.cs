using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.ItemCategories;
using Cthangband.StoreCommands;
using System;

namespace Cthangband.Stores
{
    [Serializable]
    internal class GeneralStore : Store
    {
        public GeneralStore() : base(StoreType.StoreGeneral)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Falilmawen the Friendly", 250, 108, RaceId.Hobbit),
            new StoreOwner("Voirin the Cowardly", 500, 108, RaceId.Human),
            new StoreOwner("Erashnak the Midget", 750, 107, RaceId.MiriNigri),
            new StoreOwner("Grug the Comely", 1000, 107, RaceId.HalfTitan),
            new StoreOwner("Forovir the Cheap", 250, 108, RaceId.Human),
            new StoreOwner("Ellis the Fool", 500, 108, RaceId.Human),
            new StoreOwner("Filbert the Hungry", 750, 107, RaceId.Vampire),
            new StoreOwner("Fthnargl Psathiggua", 1000, 107, RaceId.MindFlayer),
            new StoreOwner("Eloise Long-Dead", 250, 108, RaceId.Spectre),
            new StoreOwner("Fundi the Slow", 500, 108, RaceId.Zombie),
            new StoreOwner("Granthus", 750, 107, RaceId.Skeleton),
            new StoreOwner("Lorax the Suave", 1000, 107, RaceId.Vampire),
            new StoreOwner("Butch", 250, 108, RaceId.HalfOrc),
            new StoreOwner("Elbereth the Beautiful", 500, 108, RaceId.HighElf),
            new StoreOwner("Sarleth the Sneaky", 750, 107, RaceId.Gnome),
            new StoreOwner("Narlock", 1000, 107, RaceId.Dwarf),
            new StoreOwner("Haneka the Small", 250, 108, RaceId.Gnome),
            new StoreOwner("Loirin the Mad", 500, 108, RaceId.HalfGiant),
            new StoreOwner("Wuto Poisonbreath", 750, 107, RaceId.Draconian),
            new StoreOwner("Araaka the Rotund", 1000, 107, RaceId.Draconian),
            new StoreOwner("Poogor the Dumb", 250, 108, RaceId.MiriNigri),
            new StoreOwner("Felorfiliand", 500, 108, RaceId.Elf),
            new StoreOwner("Maroka the Aged", 750, 107, RaceId.Gnome),
            new StoreOwner("Sasin the Bold", 1000, 107, RaceId.HalfGiant),
            new StoreOwner("Abiemar the Peasant", 250, 108, RaceId.Human),
            new StoreOwner("Hurk the Poor", 500, 108, RaceId.HalfOrc),
            new StoreOwner("Soalin the Wretched", 750, 107, RaceId.Zombie),
            new StoreOwner("Merulla the Humble", 1000, 107, RaceId.Elf)
        };

        public override string FeatureType => "GeneralStore";

        protected override ItemIdentifier[] GetStoreTable()
        {
            return new[]
            {
                new ItemIdentifier(ItemCategory.Food, FoodType.Ration),
                new ItemIdentifier(ItemCategory.Food, FoodType.Ration),
                new ItemIdentifier(ItemCategory.Food, FoodType.Ration),
                new ItemIdentifier(ItemCategory.Food, FoodType.Ration),
                new ItemIdentifier(ItemCategory.Food, FoodType.Ration),
                new ItemIdentifier(ItemCategory.Food, FoodType.Biscuit),
                new ItemIdentifier(ItemCategory.Food, FoodType.Jerky),
                new ItemIdentifier(ItemCategory.Food, FoodType.Jerky),
                new ItemIdentifier(ItemCategory.Food, FoodType.PintOfWine),
                new ItemIdentifier(ItemCategory.Food, FoodType.PintOfAle),
                new ItemIdentifier(ItemCategory.Light, LightType.Torch),
                new ItemIdentifier(ItemCategory.Light, LightType.Torch),
                new ItemIdentifier(ItemCategory.Light, LightType.Torch),
                new ItemIdentifier(ItemCategory.Light, LightType.Lantern),
                new ItemIdentifier(ItemCategory.Light, LightType.Lantern),
                new ItemIdentifier(ItemCategory.Light, LightType.Orb),
                new ItemIdentifier(ItemCategory.Flask, 0), new ItemIdentifier(ItemCategory.Flask, 0),
                new ItemIdentifier(ItemCategory.Flask, 0), new ItemIdentifier(ItemCategory.Flask, 0),
                new ItemIdentifier(ItemCategory.Flask, 0), new ItemIdentifier(ItemCategory.Flask, 0),
                new ItemIdentifier(ItemCategory.Spike, 0), new ItemIdentifier(ItemCategory.Spike, 0),
                new ItemIdentifier(ItemCategory.Shot, AmmoType.SvAmmoNormal),
                new ItemIdentifier(ItemCategory.Arrow, AmmoType.SvAmmoNormal),
                new ItemIdentifier(ItemCategory.Bolt, AmmoType.SvAmmoNormal),
                new ItemIdentifier(ItemCategory.Digging, DiggerType.SvShovel),
                new ItemIdentifier(ItemCategory.Digging, DiggerType.SvPick),
                new ItemIdentifier(ItemCategory.Cloak, CloakType.SvCloak),
                new ItemIdentifier(ItemCategory.Cloak, CloakType.SvCloak),
                new ItemIdentifier(ItemCategory.Cloak, CloakType.SvCloak),
                new ItemIdentifier(ItemCategory.Food, FoodType.Ration),
                new ItemIdentifier(ItemCategory.Food, FoodType.Ration),
                new ItemIdentifier(ItemCategory.Food, FoodType.Ration),
                new ItemIdentifier(ItemCategory.Food, FoodType.Ration),
                new ItemIdentifier(ItemCategory.Light, LightType.Torch),
                new ItemIdentifier(ItemCategory.Light, LightType.Torch),
                new ItemIdentifier(ItemCategory.Light, LightType.Lantern),
                new ItemIdentifier(ItemCategory.Light, LightType.Lantern),
                new ItemIdentifier(ItemCategory.Flask, 0), new ItemIdentifier(ItemCategory.Flask, 0),
                new ItemIdentifier(ItemCategory.Flask, 0), new ItemIdentifier(ItemCategory.Flask, 0),
                new ItemIdentifier(ItemCategory.Shot, AmmoType.SvAmmoNormal),
                new ItemIdentifier(ItemCategory.Arrow, AmmoType.SvAmmoNormal),
                new ItemIdentifier(ItemCategory.Bolt, AmmoType.SvAmmoNormal),
                new ItemIdentifier(ItemCategory.Digging, DiggerType.SvShovel)
            };
        }

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.ItemType.BaseCategory)
            {
                case FoodItemCategory _:
                case LightItemCategory _:
                case FlaskItemCategory _:
                case SpikeItemCategory _:
                case ShotItemCategory _:
                case ArrowItemCategory _:
                case BoltItemCategory _:
                case DiggingItemCategory _:
                case CloakItemCategory _:
                case BottleItemCategory _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }

        protected override IStoreCommand AdvertisedStoreCommand4 => new HireEscortStoreCommand();
    }
}
