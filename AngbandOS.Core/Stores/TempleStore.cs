using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.Races;

namespace AngbandOS.Stores
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
            new StoreOwner("Ludwig the Humble", 10000, 109, new DwarfRace()),
            new StoreOwner("Gunnar the Paladin", 15000, 110, new HalfTrollRace()),
            new StoreOwner("Sir Parsival the Pure", 25000, 107, new HighElfRace()),
            new StoreOwner("Asenath the Holy", 30000, 109, new HumanRace()),
            new StoreOwner("McKinnon", 10000, 109, new HumanRace()),
            new StoreOwner("Mistress Chastity", 15000, 110, new HighElfRace()),
            new StoreOwner("Hashnik the Druid", 25000, 107, new HobbitRace()),
            new StoreOwner("Finak", 30000, 109, new YeekRace()),
            new StoreOwner("Krikkik", 10000, 109, new KlackonRace()),
            new StoreOwner("Morival the Wild", 15000, 110, new ElfRace()),
            new StoreOwner("Hoshak the Dark", 25000, 107, new ImpRace()),
            new StoreOwner("Atal the Wise", 30000, 109, new HumanRace()),
            new StoreOwner("Ibenidd the Chaste", 10000, 109, new HumanRace()),
            new StoreOwner("Eridish", 15000, 110, new HalfTrollRace()),
            new StoreOwner("Vrudush the Shaman", 25000, 107, new HalfOgreRace()),
            new StoreOwner("Haob the Berserker", 30000, 109, new TchoTchoRace()),
            new StoreOwner("Proogdish the Youthfull", 10000, 109, new HalfOgreRace()),
            new StoreOwner("Lumwise the Mad", 15000, 110, new YeekRace()),
            new StoreOwner("Muirt the Virtuous", 25000, 107, new KoboldRace()),
            new StoreOwner("Dardobard the Weak", 30000, 109, new SpectreRace())
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

        public override bool ItemMatches(Item item)
        {
            switch (item.BaseItemCategory)
            {
                case LifeBookItemClass _:
                case ScrollItemClass _:
                case PotionItemClass _:
                case HaftedItemClass _:
                    return item.Value() > 0;
                case PolearmItemClass _:
                case SwordItemClass _:
                    item.RefreshFlagBasedProperties();
                    if (item.Characteristics.Blessed)
                        return item.Value() > 0;
                    else
                        return false;
                default:
                    return false;
            }
        }
        protected override BaseStoreCommand AdvertisedStoreCommand4 => new RemoveCurseStoreCommand();
        protected override BaseStoreCommand AdvertisedStoreCommand5 => new SacrificeStoreCommand();
    }
}
