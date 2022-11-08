using AngbandOS.Commands;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.StoreCommands;
using System;

namespace AngbandOS.Stores
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

        public AlchemistStore(SaveGame saveGame) : base(saveGame, StoreType.StoreAlchemist)
        {
        }

        public override string FeatureType => "Alchemist";

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(PotionRestoreCharisma), 2),
                new StockStoreInventoryItem(typeof(PotionRestoreConstitution), 2),
                new StockStoreInventoryItem(typeof(PotionRestoreDexterity), 2),
                new StockStoreInventoryItem(typeof(PotionRestoreIntelligence), 2),
                new StockStoreInventoryItem(typeof(PotionRestoreStrength), 2),
                new StockStoreInventoryItem(typeof(PotionRestoreWisdom), 2),
                new StockStoreInventoryItem(typeof(ScrollDetectInvisible)),
                new StockStoreInventoryItem(typeof(ScrollEnchantArmor), 3),
                new StockStoreInventoryItem(typeof(ScrollEnchantWeaponToDam)),
                new StockStoreInventoryItem(typeof(ScrollEnchantWeaponToHit)),
                new StockStoreInventoryItem(typeof(ScrollIdentify), 6),
                new StockStoreInventoryItem(typeof(ScrollLight), 2),
                new StockStoreInventoryItem(typeof(ScrollMagicMapping)),
                new StockStoreInventoryItem(typeof(ScrollMonsterConfusion)),
                new StockStoreInventoryItem(typeof(ScrollObjectDetection)),
                new StockStoreInventoryItem(typeof(ScrollPhaseDoor), 2),
                new StockStoreInventoryItem(typeof(ScrollRecharging), 2),
                new StockStoreInventoryItem(typeof(ScrollSatisfyHunger), 4),
                new StockStoreInventoryItem(typeof(ScrollSpecialIdentify), 2),
                new StockStoreInventoryItem(typeof(ScrollTeleportation), 3),
                new StockStoreInventoryItem(typeof(ScrollTrapDetection)),
                new StockStoreInventoryItem(typeof(ScrollTreasureDetection)),
                new StockStoreInventoryItem(typeof(ScrollWordOfRecall), 4),
            };
        }

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.BaseItemCategory)
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
