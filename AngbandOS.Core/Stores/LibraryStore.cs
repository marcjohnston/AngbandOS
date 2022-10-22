using AngbandOS.Commands;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.StoreCommands;
using System;

namespace AngbandOS.Stores
{
    [Serializable]
    internal class LibraryStore : Store
    {
        public LibraryStore(SaveGame saveGame) : base(saveGame, StoreType.StoreLibrary)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Randolph Carter", 15000, 108, RaceId.Human),
            new StoreOwner("Odnar the Sage", 20000, 105, RaceId.HighElf),
            new StoreOwner("Gandar the Neutral", 25000, 110, RaceId.Vampire),
            new StoreOwner("Ro-sha the Patient", 30000, 105, RaceId.Golem),
            new StoreOwner("Sarai the Swift", 15000, 108, RaceId.Human),
            new StoreOwner("Bodril the Seer", 20000, 105, RaceId.HighElf),
            new StoreOwner("Veloin the Quiet", 25000, 110, RaceId.Zombie),
            new StoreOwner("Vanthylas the Learned", 30000, 105, RaceId.MindFlayer),
            new StoreOwner("Ossein the Literate", 15000, 108, RaceId.Skeleton),
            new StoreOwner("Olvar Bookworm", 20000, 105, RaceId.Vampire),
            new StoreOwner("Shallowgrave", 25000, 110, RaceId.Zombie),
            new StoreOwner("Death Mask", 30000, 105, RaceId.Zombie),
            new StoreOwner("Porcina the Obese", 15000, 108, RaceId.HalfOrc),
            new StoreOwner("Glaruna Brandybreath", 20000, 105, RaceId.Dwarf),
            new StoreOwner("Furface Yeek", 25000, 110, RaceId.Yeek),
            new StoreOwner("Bald Oggin", 30000, 105, RaceId.Gnome),
            new StoreOwner("Asuunu the Learned", 15000, 108, RaceId.MindFlayer),
            new StoreOwner("Prirand the Dead", 20000, 105, RaceId.Zombie),
            new StoreOwner("Ronar the Iron", 25000, 110, RaceId.Golem),
            new StoreOwner("Galil-Gamir", 30000, 105, RaceId.Elf),
            new StoreOwner("Rorbag Book-Eater", 15000, 108, RaceId.Kobold),
            new StoreOwner("Kiriarikirk", 20000, 105, RaceId.Klackon),
            new StoreOwner("Rilin the Quiet", 25000, 110, RaceId.Dwarf),
            new StoreOwner("Isung the Lord", 30000, 105, RaceId.HighElf)
        };

        public override string FeatureType => "Bookstore";

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(ChaosBookChaosMastery), 2),
                new StockStoreInventoryItem(typeof(ChaosBookSignofChaos), 2),
                new StockStoreInventoryItem(typeof(CorporealBookBasicChiFlow), 2),
                new StockStoreInventoryItem(typeof(CorporealBookYogicMastery), 2),
                new StockStoreInventoryItem(typeof(DeathBookBlackMass), 4),
                new StockStoreInventoryItem(typeof(DeathBookBlackPrayers), 4),
                new StockStoreInventoryItem(typeof(FolkBookCantripsforBeginners), 2),
                new StockStoreInventoryItem(typeof(FolkBookMagicksofMastery), 2),
                new StockStoreInventoryItem(typeof(FolkBookMajorMagicks), 2),
                new StockStoreInventoryItem(typeof(FolkBookMinorMagicks), 2),
                new StockStoreInventoryItem(typeof(LifeBookBookofCommonPrayer), 4),
                new StockStoreInventoryItem(typeof(LifeBookHighMass), 4),
                new StockStoreInventoryItem(typeof(NatureBookCallOfTheWild), 4),
                new StockStoreInventoryItem(typeof(NatureBookNatureMastery), 4),
                new StockStoreInventoryItem(typeof(SorceryBookBeginnersHandbook), 2),
                new StockStoreInventoryItem(typeof(SorceryBookMasterSorcerersHandbook), 2),
                new StockStoreInventoryItem(typeof(TarotBookCardMastery), 2),
                new StockStoreInventoryItem(typeof(TarotBookConjuringsTricks), 2),
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
                case LifeBookItemCategory _:
                case TarotBookItemCategory _:
                case FolkBookItemCategory _:
                case CorporealBookItemCategory _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override IStoreCommand AdvertisedStoreCommand4 => new ResearchSpellStoreCommand();
    }
}
