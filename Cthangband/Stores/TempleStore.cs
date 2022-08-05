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
        public TempleStore() : base(StoreType.StoreTemple)
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

        protected override ItemIdentifier[] GetStoreTable()
        {
            return new[]
            {
                new ItemIdentifier(typeof(HaftedWhip)),
                new ItemIdentifier(typeof(HaftedQuarterstaff)),
                new ItemIdentifier(typeof(HaftedMace)),
                new ItemIdentifier(typeof(HaftedBallAndChain)),
                new ItemIdentifier(typeof(HaftedWarHammer)),
                new ItemIdentifier(typeof(HaftedLucerneHammer)),
                new ItemIdentifier(typeof(HaftedMorningStar)),
                new ItemIdentifier(typeof(HaftedFlail)),
                new ItemIdentifier(typeof(HaftedLeadFilledMace)),
                new ItemIdentifier(typeof(ScrollRemoveCurse)),
                new ItemIdentifier(typeof(ScrollBlessing)),
                new ItemIdentifier(typeof(ScrollHolyChant)),
                new ItemIdentifier(typeof(PotionHeroism)),
                new ItemIdentifier(typeof(ScrollWordOfRecall)),
                new ItemIdentifier(typeof(ScrollWordOfRecall)),
                new ItemIdentifier(typeof(ScrollWordOfRecall)),
                new ItemIdentifier(typeof(PotionCureLightWounds)),
                new ItemIdentifier(typeof(PotionCureSeriousWounds)),
                new ItemIdentifier(typeof(PotionCureSeriousWounds)),
                new ItemIdentifier(typeof(PotionCureCriticalWounds)),
                new ItemIdentifier(typeof(PotionCureCriticalWounds)),
                new ItemIdentifier(typeof(PotionRestoreLifeLevels)),
                new ItemIdentifier(typeof(PotionRestoreLifeLevels)),
                new ItemIdentifier(typeof(PotionRestoreLifeLevels)),
                new ItemIdentifier(typeof(LifeBookBookofCommonPrayer)),
                new ItemIdentifier(typeof(LifeBookBookofCommonPrayer)),
                new ItemIdentifier(typeof(LifeBookBookofCommonPrayer)),
                new ItemIdentifier(typeof(LifeBookBookofCommonPrayer)),
                new ItemIdentifier(typeof(LifeBookHighMass)),
                new ItemIdentifier(typeof(LifeBookHighMass)),
                new ItemIdentifier(typeof(LifeBookHighMass)),
                new ItemIdentifier(typeof(LifeBookHighMass)),
                new ItemIdentifier(typeof(HaftedWhip)),
                new ItemIdentifier(typeof(HaftedMace)),
                new ItemIdentifier(typeof(HaftedBallAndChain)),
                new ItemIdentifier(typeof(HaftedWarHammer)),
                new ItemIdentifier(typeof(ScrollWordOfRecall)),
                new ItemIdentifier(typeof(ScrollWordOfRecall)),
                new ItemIdentifier(typeof(ScrollWordOfRecall)),
                new ItemIdentifier(typeof(PotionCureCriticalWounds)),
                new ItemIdentifier(typeof(PotionCureCriticalWounds)),
                new ItemIdentifier(typeof(PotionRestoreLifeLevels)),
                new ItemIdentifier(typeof(PotionRestoreLifeLevels)),
                new ItemIdentifier(typeof(PotionRestoreLifeLevels)),
                new ItemIdentifier(typeof(ScrollRemoveCurse)),
                new ItemIdentifier(typeof(ScrollRemoveCurse)),
                new ItemIdentifier(typeof(ScrollSpecialRemoveCurse)),
                new ItemIdentifier(typeof(ScrollSpecialRemoveCurse)),
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
