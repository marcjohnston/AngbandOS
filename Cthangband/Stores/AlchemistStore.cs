using Cthangband.Commands;
using Cthangband.Enumerations;
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
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.EnchantWeaponToHit),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.EnchantWeaponToDam),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.EnchantArmor),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Identify),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Identify),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Identify),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Identify),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Light),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.PhaseDoor),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.PhaseDoor),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Teleport),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.MonsterConfusion),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Mapping),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.DetectGold),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.DetectItem),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.DetectTrap),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.DetectInvis),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Recharging),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.SatisfyHunger),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.WordOfRecall),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.WordOfRecall),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.WordOfRecall),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.WordOfRecall),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Teleport),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Teleport),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResStr),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResInt),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResWis),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResDex),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResCon),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResCha),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Identify),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Identify),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.StarIdentify),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.StarIdentify),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Light),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResStr),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResInt),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResWis),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResDex),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResCon),
                new ItemIdentifier(ItemCategory.Potion, PotionType.ResCha),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.EnchantArmor),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.EnchantArmor),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.Recharging),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.SatisfyHunger),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.SatisfyHunger),
                new ItemIdentifier(ItemCategory.Scroll, ScrollType.SatisfyHunger)
            };
        }

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.Category)
            {
                case ItemCategory.Scroll:
                case ItemCategory.Potion:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override IStoreCommand AdvertisedStoreCommand4 => new RestorationStoreCommand();
    }
}
