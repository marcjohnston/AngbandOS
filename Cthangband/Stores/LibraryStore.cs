using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.ItemCategories;
using Cthangband.StoreCommands;
using System;

namespace Cthangband.Stores
{
    [Serializable]
    internal class LibraryStore : Store
    {
        public LibraryStore() : base(StoreType.StoreLibrary)
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

        protected override ItemIdentifier[] GetStoreTable()
        {
            return new[]
            {
                new ItemIdentifier(typeof(SorceryBookBeginnersHandbook)),
                new ItemIdentifier(typeof(SorceryBookBeginnersHandbook)),
                new ItemIdentifier(typeof(SorceryBookMasterSorcerersHandbook)),
                new ItemIdentifier(typeof(SorceryBookMasterSorcerersHandbook)),
                new ItemIdentifier(typeof(NatureBookCallOfTheWild)),
                new ItemIdentifier(typeof(NatureBookCallOfTheWild)),
                new ItemIdentifier(typeof(NatureBookNatureMastery)),
                new ItemIdentifier(typeof(NatureBookNatureMastery)),
                new ItemIdentifier(typeof(ChaosBookSignofChaos)),
                new ItemIdentifier(typeof(ChaosBookSignofChaos)),
                new ItemIdentifier(typeof(ChaosBookChaosMastery)),
                new ItemIdentifier(typeof(ChaosBookChaosMastery)),
                new ItemIdentifier(typeof(DeathBookBlackPrayers)),
                new ItemIdentifier(typeof(DeathBookBlackPrayers)),
                new ItemIdentifier(typeof(DeathBookBlackMass)),
                new ItemIdentifier(typeof(DeathBookBlackMass)),
                new ItemIdentifier(typeof(TarotBookConjuringsTricks)),
                new ItemIdentifier(typeof(TarotBookConjuringsTricks)),
                new ItemIdentifier(typeof(TarotBookCardMastery)),
                new ItemIdentifier(typeof(TarotBookCardMastery)),
                new ItemIdentifier(typeof(FolkBookCantripsforBeginners)),
                new ItemIdentifier(typeof(FolkBookCantripsforBeginners)),
                new ItemIdentifier(typeof(FolkBookMinorMagicks)),
                new ItemIdentifier(typeof(FolkBookMinorMagicks)),
                new ItemIdentifier(typeof(FolkBookMajorMagicks)),
                new ItemIdentifier(typeof(FolkBookMajorMagicks)),
                new ItemIdentifier(typeof(FolkBookMagicksofMastery)),
                new ItemIdentifier(typeof(FolkBookMagicksofMastery)),
                new ItemIdentifier(typeof(LifeBookBookofCommonPrayer)),
                new ItemIdentifier(typeof(LifeBookBookofCommonPrayer)),
                new ItemIdentifier(typeof(LifeBookBookofCommonPrayer)),
                new ItemIdentifier(typeof(LifeBookBookofCommonPrayer)),
                new ItemIdentifier(typeof(LifeBookHighMass)),
                new ItemIdentifier(typeof(LifeBookHighMass)),
                new ItemIdentifier(typeof(LifeBookHighMass)),
                new ItemIdentifier(typeof(LifeBookHighMass)),
                new ItemIdentifier(typeof(DeathBookBlackPrayers)),
                new ItemIdentifier(typeof(DeathBookBlackPrayers)),
                new ItemIdentifier(typeof(DeathBookBlackMass)),
                new ItemIdentifier(typeof(DeathBookBlackMass)),
                new ItemIdentifier(typeof(CorporealBookBasicChiFlow)),
                new ItemIdentifier(typeof(CorporealBookBasicChiFlow)),
                new ItemIdentifier(typeof(CorporealBookYogicMastery)),
                new ItemIdentifier(typeof(CorporealBookYogicMastery)),
                new ItemIdentifier(typeof(NatureBookCallOfTheWild)),
                new ItemIdentifier(typeof(NatureBookCallOfTheWild)),
                new ItemIdentifier(typeof(NatureBookNatureMastery)),
                new ItemIdentifier(typeof(NatureBookNatureMastery))
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
