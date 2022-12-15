using AngbandOS.Commands;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Core.Races;
using AngbandOS.Enumerations;
using AngbandOS.StoreCommands;

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
            new StoreOwner("Falilmawen the Friendly", 250, 108, new HobbitRace()),
            new StoreOwner("Voirin the Cowardly", 500, 108, new HumanRace()),
            new StoreOwner("Erashnak the Midget", 750, 107, new MiriNigriRace()),
            new StoreOwner("Grug the Comely", 1000, 107, new HalfTitanRace()),
            new StoreOwner("Forovir the Cheap", 250, 108, new HumanRace()),
            new StoreOwner("Ellis the Fool", 500, 108, new HumanRace()),
            new StoreOwner("Filbert the Hungry", 750, 107, new VampireRace()),
            new StoreOwner("Fthnargl Psathiggua", 1000, 107, new MindFlayerRace()),
            new StoreOwner("Eloise Long-Dead", 250, 108, new SpectreRace()),
            new StoreOwner("Fundi the Slow", 500, 108, new ZombieRace()),
            new StoreOwner("Granthus", 750, 107, new SkeletonRace()),
            new StoreOwner("Lorax the Suave", 1000, 107, new VampireRace()),
            new StoreOwner("Butch", 250, 108, new HalfOrcRace()),
            new StoreOwner("Elbereth the Beautiful", 500, 108, new HighElfRace()),
            new StoreOwner("Sarleth the Sneaky", 750, 107, new GnomeRace()),
            new StoreOwner("Narlock", 1000, 107, new DwarfRace()),
            new StoreOwner("Haneka the Small", 250, 108, new GnomeRace()),
            new StoreOwner("Loirin the Mad", 500, 108, new HalfGiantRace()),
            new StoreOwner("Wuto Poisonbreath", 750, 107, new DraconianRace()),
            new StoreOwner("Araaka the Rotund", 1000, 107, new DraconianRace()),
            new StoreOwner("Poogor the Dumb", 250, 108, new MiriNigriRace()),
            new StoreOwner("Felorfiliand", 500, 108, new ElfRace()),
            new StoreOwner("Maroka the Aged", 750, 107, new GnomeRace()),
            new StoreOwner("Sasin the Bold", 1000, 107, new HalfGiantRace()),
            new StoreOwner("Abiemar the Peasant", 250, 108, new HumanRace()),
            new StoreOwner("Hurk the Poor", 500, 108, new HalfOrcRace()),
            new StoreOwner("Soalin the Wretched", 750, 107, new ZombieRace()),
            new StoreOwner("Merulla the Humble", 1000, 107, new ElfRace())
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
                case FoodItemClass _:
                case LightSourceItemClass _:
                case FlaskItemClass _:
                case SpikeItemClass _:
                case ShotItemClass _:
                case ArrowItemClass _:
                case BoltItemClass _:
                case DiggingItemClass _:
                case CloakItemClass _:
                case BottleItemClass _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }

        protected override IStoreCommand AdvertisedStoreCommand4 => new HireEscortStoreCommand();
    }
}
