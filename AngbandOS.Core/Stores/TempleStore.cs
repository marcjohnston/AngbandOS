using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.ItemCategories;
using Cthangband.Patrons;
using Cthangband.StoreCommands;
using System;

namespace Cthangband.Stores
{
    [Serializable]
    internal class TempleStore : Store
    {
        public TempleStore(SaveGame saveGame) : base(saveGame, StoreType.StoreTemple)
        {
        }

        public override string FeatureType => "Temple";

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Ludwig the Humble", 10000, 109, RaceId.Dwarf),
            new StoreOwner("Gunnar the Paladin", 15000, 110, RaceId.HalfTroll),
            new StoreOwner("Sir Parsival the Pure", 25000, 107, RaceId.HighElf),
            new StoreOwner("Asenath the Holy", 30000, 109, RaceId.Human),
            new StoreOwner("McKinnon", 10000, 109, RaceId.Human),
            new StoreOwner("Mistress Chastity", 15000, 110, RaceId.HighElf),
            new StoreOwner("Hashnik the Druid", 25000, 107, RaceId.Hobbit),
            new StoreOwner("Finak", 30000, 109, RaceId.Yeek), new StoreOwner("Krikkik", 10000, 109, RaceId.Klackon),
            new StoreOwner("Morival the Wild", 15000, 110, RaceId.Elf),
            new StoreOwner("Hoshak the Dark", 25000, 107, RaceId.Imp),
            new StoreOwner("Atal the Wise", 30000, 109, RaceId.Human),
            new StoreOwner("Ibenidd the Chaste", 10000, 109, RaceId.Human),
            new StoreOwner("Eridish", 15000, 110, RaceId.HalfTroll),
            new StoreOwner("Vrudush the Shaman", 25000, 107, RaceId.HalfOgre),
            new StoreOwner("Haob the Berserker", 30000, 109, RaceId.TchoTcho),
            new StoreOwner("Proogdish the Youthfull", 10000, 109, RaceId.HalfOgre),
            new StoreOwner("Lumwise the Mad", 15000, 110, RaceId.Yeek),
            new StoreOwner("Muirt the Virtuous", 25000, 107, RaceId.Kobold),
            new StoreOwner("Dardobard the Weak", 30000, 109, RaceId.Spectre)
        };

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(HaftedBallAndChain), 2),
                new StockStoreInventoryItem(typeof(HaftedFlail)),
                new StockStoreInventoryItem(typeof(HaftedLeadFilledMace)),
                new StockStoreInventoryItem(typeof(HaftedLucerneHammer)),
                new StockStoreInventoryItem(typeof(HaftedMace), 2),
                new StockStoreInventoryItem(typeof(HaftedMorningStar)),
                new StockStoreInventoryItem(typeof(HaftedQuarterstaff)),
                new StockStoreInventoryItem(typeof(HaftedWarHammer), 2),
                new StockStoreInventoryItem(typeof(HaftedWhip), 2),
                new StockStoreInventoryItem(typeof(LifeBookBookofCommonPrayer), 4),
                new StockStoreInventoryItem(typeof(LifeBookHighMass), 4),
                new StockStoreInventoryItem(typeof(PotionCureCriticalWounds), 4),
                new StockStoreInventoryItem(typeof(PotionCureLightWounds)),
                new StockStoreInventoryItem(typeof(PotionCureSeriousWounds), 2),
                new StockStoreInventoryItem(typeof(PotionHeroism)),
                new StockStoreInventoryItem(typeof(PotionRestoreLifeLevels), 6),
                new StockStoreInventoryItem(typeof(ScrollBlessing)),
                new StockStoreInventoryItem(typeof(ScrollHolyChant)),
                new StockStoreInventoryItem(typeof(ScrollRemoveCurse), 3),
                new StockStoreInventoryItem(typeof(ScrollSpecialRemoveCurse), 2),
                new StockStoreInventoryItem(typeof(ScrollWordOfRecall), 6),
            };
        }

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.ItemType.BaseCategory)
            {
                case LifeBookItemCategory _:
                case ScrollItemCategory _:
                case PotionItemCategory _:
                case HaftedItemCategory _:
                    return item.Value() > 0;
                case PolearmItemCategory _:
                case SwordItemCategory _:
                    if (item.IsBlessed())
                        return item.Value() > 0;
                    else
                        return false;
                default:
                    return false;
            }
        }
        protected override IStoreCommand AdvertisedStoreCommand4 => new RemoveCurseStoreCommand();
        protected override IStoreCommand AdvertisedStoreCommand5 => new SacrificeStoreCommand();
    }
}
