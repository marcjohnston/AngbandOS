using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.ItemCategories;
using Cthangband.StoreCommands;
using System;

namespace Cthangband.Stores
{
    [Serializable]
    internal class AlchemistStore : Store
    {
        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Mauser the Chemist", 10000, 111, RaceId.HalfElf),
            new StoreOwner("Wizzle the Chaotic", 10000, 110, RaceId.Hobbit),
            new StoreOwner("Kakalrakakal", 15000, 116, RaceId.Klackon),
            new StoreOwner("Jal-Eth the Alchemist", 15000, 111, RaceId.Elf),
            new StoreOwner("Fanelath the Cautious", 10000, 111, RaceId.Dwarf),
            new StoreOwner("Runcie the Insane", 10000, 110, RaceId.Human),
            new StoreOwner("Grumbleworth", 15000, 116, RaceId.Gnome),
            new StoreOwner("Flitter", 15000, 111, RaceId.Sprite), new StoreOwner("Xarillus", 10000, 111, RaceId.Human),
            new StoreOwner("Egbert the Old", 10000, 110, RaceId.Dwarf),
            new StoreOwner("Valindra the Proud", 15000, 116, RaceId.HighElf),
            new StoreOwner("Taen the Alchemist", 15000, 111, RaceId.Human),
            new StoreOwner("Cayd the Sweet", 10000, 111, RaceId.Vampire),
            new StoreOwner("Fulir the Dark", 10000, 110, RaceId.Nibelung),
            new StoreOwner("Domli the Humble", 15000, 116, RaceId.Dwarf),
            new StoreOwner("Yaarjukka Demonspawn", 15000, 111, RaceId.Imp),
            new StoreOwner("Gelaraldor the Herbmaster", 10000, 111, RaceId.HighElf),
            new StoreOwner("Olelaldan the Wise", 10000, 110, RaceId.TchoTcho),
            new StoreOwner("Fthoglo the Demonicist", 15000, 116, RaceId.Imp),
            new StoreOwner("Dridash the Alchemist", 15000, 111, RaceId.HalfOrc)
        };

        public AlchemistStore() : base(StoreType.StoreAlchemist)
        {
        }

        public override string FeatureType => "Alchemist";

        protected override ItemIdentifier[] GetStoreTable()
        {
            return new[]
            {
                new ItemIdentifier(typeof(ScrollEnchantWeaponToHit)),
                new ItemIdentifier(typeof(ScrollEnchantWeaponToDam)),
                new ItemIdentifier(typeof(ScrollEnchantArmor)),
                new ItemIdentifier(typeof(ScrollIdentify)),
                new ItemIdentifier(typeof(ScrollIdentify)),
                new ItemIdentifier(typeof(ScrollIdentify)),
                new ItemIdentifier(typeof(ScrollIdentify)),
                new ItemIdentifier(typeof(ScrollLight)),
                new ItemIdentifier(typeof(ScrollPhaseDoor)),
                new ItemIdentifier(typeof(ScrollPhaseDoor)),
                new ItemIdentifier(typeof(ScrollTeleportation)),
                new ItemIdentifier(typeof(ScrollMonsterConfusion)),
                new ItemIdentifier(typeof(ScrollMagicMapping)),
                new ItemIdentifier(typeof(ScrollTreasureDetection)),
                new ItemIdentifier(typeof(ScrollObjectDetection)),
                new ItemIdentifier(typeof(ScrollTrapDetection)),
                new ItemIdentifier(typeof(ScrollDetectInvisible)),
                new ItemIdentifier(typeof(ScrollRecharging)),
                new ItemIdentifier(typeof(ScrollSatisfyHunger)),
                new ItemIdentifier(typeof(ScrollWordOfRecall)),
                new ItemIdentifier(typeof(ScrollWordOfRecall)),
                new ItemIdentifier(typeof(ScrollWordOfRecall)),
                new ItemIdentifier(typeof(ScrollWordOfRecall)),
                new ItemIdentifier(typeof(ScrollTeleportation)),
                new ItemIdentifier(typeof(ScrollTeleportation)),
                new ItemIdentifier(typeof(PotionRestoreStrength)),
                new ItemIdentifier(typeof(PotionRestoreIntelligence)),
                new ItemIdentifier(typeof(PotionRestoreWisdom)),
                new ItemIdentifier(typeof(PotionRestoreDexterity)),
                new ItemIdentifier(typeof(PotionRestoreConstitution)),
                new ItemIdentifier(typeof(PotionRestoreCharisma)),
                new ItemIdentifier(typeof(ScrollIdentify)),
                new ItemIdentifier(typeof(ScrollIdentify)),
                new ItemIdentifier(typeof(ScrollSpecialIdentify)),
                new ItemIdentifier(typeof(ScrollSpecialIdentify)),
                new ItemIdentifier(typeof(ScrollLight)),
                new ItemIdentifier(typeof(PotionRestoreStrength)),
                new ItemIdentifier(typeof(PotionRestoreIntelligence)),
                new ItemIdentifier(typeof(PotionRestoreWisdom)),
                new ItemIdentifier(typeof(PotionRestoreDexterity)),
                new ItemIdentifier(typeof(PotionRestoreConstitution)),
                new ItemIdentifier(typeof(PotionRestoreCharisma)),
                new ItemIdentifier(typeof(ScrollEnchantArmor)),
                new ItemIdentifier(typeof(ScrollEnchantArmor)),
                new ItemIdentifier(typeof(ScrollRecharging)),
                new ItemIdentifier(typeof(ScrollSatisfyHunger)),
                new ItemIdentifier(typeof(ScrollSatisfyHunger)),
                new ItemIdentifier(typeof(ScrollSatisfyHunger))
            };
        }

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.ItemType.BaseCategory)
            {
                case ScrollItemCategory _:
                case PotionItemCategory _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override IStoreCommand AdvertisedStoreCommand4 => new RestorationStoreCommand();
    }
}
