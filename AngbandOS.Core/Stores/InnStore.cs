using AngbandOS.Commands;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.StoreCommands;
using System;

namespace AngbandOS.Stores
{
    [Serializable]
    internal class InnStore : Store
    {
        public InnStore(SaveGame saveGame) : base(saveGame, StoreType.StoreInn)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Mordsan", 15000, 108, RaceId.Human),
            new StoreOwner("Furfoot Pobber", 20000, 105, RaceId.Hobbit),
            new StoreOwner("Oddo Yeekson", 25000, 110, RaceId.Yeek),
            new StoreOwner("Dry-Bones", 30000, 105, RaceId.Skeleton),
            new StoreOwner("Kleibons", 15000, 108, RaceId.Klackon),
            new StoreOwner("Prendegast", 20000, 105, RaceId.Hobbit),
            new StoreOwner("Straasha", 25000, 110, RaceId.Draconian),
            new StoreOwner("Allia the Servile", 30000, 105, RaceId.Human),
            new StoreOwner("Lumin the Blue", 15000, 108, RaceId.Spectre),
            new StoreOwner("Short Al", 20000, 105, RaceId.Zombie),
            new StoreOwner("Silent Faldus", 25000, 110, RaceId.Zombie),
            new StoreOwner("Quirmby the Strange", 30000, 105, RaceId.Vampire),
            new StoreOwner("Aldous the Sleepy", 15000, 108, RaceId.Human),
            new StoreOwner("Grundy the Tall", 20000, 105, RaceId.Hobbit),
            new StoreOwner("Gobbleguts Thunderbreath", 25000, 110, RaceId.HalfTroll),
            new StoreOwner("Silverscale", 30000, 105, RaceId.Draconian),
            new StoreOwner("Etheraa the Furious", 15000, 108, RaceId.TchoTcho),
            new StoreOwner("Paetlan the Alcoholic", 20000, 105, RaceId.Human),
            new StoreOwner("Drang", 25000, 110, RaceId.HalfOgre),
            new StoreOwner("Barbag the Sly", 30000, 105, RaceId.Kobold),
            new StoreOwner("Kirakak", 15000, 108, RaceId.Klackon),
            new StoreOwner("Nafur the Wooden", 20000, 105, RaceId.Golem),
            new StoreOwner("Grarak the Hospitable", 25000, 110, RaceId.HalfGiant),
            new StoreOwner("Lona the Charismatic", 30000, 105, RaceId.Gnome),
            new StoreOwner("Crediric the Brewer", 15000, 108, RaceId.Human),
            new StoreOwner("Nydudus the Slow", 20000, 105, RaceId.Zombie),
            new StoreOwner("Baurk the Busy", 25000, 110, RaceId.Yeek),
            new StoreOwner("Seviras the Mindcrafter", 30000, 105, RaceId.Human)
        };

        public override string FeatureType => "Inn";

        public override bool ItemMatches(Item item)
        {
            return false;
        }

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(FoodHardBiscuit), 2),
                new StockStoreInventoryItem(typeof(FoodPintOfFineAle), 10),
                new StockStoreInventoryItem(typeof(FoodPintOfFineWine), 10),
                new StockStoreInventoryItem(typeof(FoodRation), 18),
                new StockStoreInventoryItem(typeof(FoodStripOfVenison), 4),
                new StockStoreInventoryItem(typeof(ScrollSatisfyHunger), 4),
            };
        }

        public override int StoreMaxKeep => 4;
        protected override IStoreCommand AdvertisedStoreCommand4 => new HireRoomStoreCommand();
        protected override bool PerformsMaintenanceWhenResting => false;
    }
}
