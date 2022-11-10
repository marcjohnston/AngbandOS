using AngbandOS.Commands;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.StoreCommands;
using System;

namespace AngbandOS.Stores
{
    [Serializable]
    internal class GeneralStore : Store
    {
        public GeneralStore(SaveGame saveGame) : base(saveGame, StoreType.StoreGeneral)
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

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(Arrow), 2),
                new StockStoreInventoryItem(typeof(Bolt), 2),
                new StockStoreInventoryItem(typeof(Cloak), 3),
                new StockStoreInventoryItem(typeof(DiggingPick)),
                new StockStoreInventoryItem(typeof(DiggingShovel), 2),
                new StockStoreInventoryItem(typeof(FlaskOfOil), 10),
                new StockStoreInventoryItem(typeof(FoodHardBiscuit)),
                new StockStoreInventoryItem(typeof(FoodPintOfFineAle)),
                new StockStoreInventoryItem(typeof(FoodPintOfFineWine)),
                new StockStoreInventoryItem(typeof(FoodRation), 9),
                new StockStoreInventoryItem(typeof(FoodStripOfVenison), 2),
                new StockStoreInventoryItem(typeof(LightBrassLantern), 4),
                new StockStoreInventoryItem(typeof(LightOrb)),
                new StockStoreInventoryItem(typeof(LightWoodenTorch), 5),
                new StockStoreInventoryItem(typeof(ShotIronShot), 2),
                new StockStoreInventoryItem(typeof(SpikeIronSpike), 2),
            };
        }

        public override bool ItemMatches(Item item)
        {
            switch (item.BaseItemCategory)
            {
                case FoodItemCategory _:
                case LightSourceItemClass _:
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
