using AngbandOS.Commands;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Core.Races;
using AngbandOS.Enumerations;
using AngbandOS.StoreCommands;

namespace AngbandOS.Stores
{
    [Serializable]
    internal class AlchemistStore : Store
    {
        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Mauser the Chemist", 10000, 111, new HalfElfRace()),
            new StoreOwner("Wizzle the Chaotic", 10000, 110, new HobbitRace()),
            new StoreOwner("Kakalrakakal", 15000, 116, new KlackonRace()),
            new StoreOwner("Jal-Eth the Alchemist", 15000, 111, new ElfRace()),
            new StoreOwner("Fanelath the Cautious", 10000, 111, new DwarfRace()),
            new StoreOwner("Runcie the Insane", 10000, 110, new HumanRace()),
            new StoreOwner("Grumbleworth", 15000, 116, new GnomeRace()),
            new StoreOwner("Flitter", 15000, 111, new SpriteRace()),
            new StoreOwner("Xarillus", 10000, 111, new HumanRace()),
            new StoreOwner("Egbert the Old", 10000, 110, new DwarfRace()),
            new StoreOwner("Valindra the Proud", 15000, 116, new HighElfRace()),
            new StoreOwner("Taen the Alchemist", 15000, 111, new HumanRace()),
            new StoreOwner("Cayd the Sweet", 10000, 111, new VampireRace()),
            new StoreOwner("Fulir the Dark", 10000, 110, new NibelungRace()),
            new StoreOwner("Domli the Humble", 15000, 116, new DwarfRace()),
            new StoreOwner("Yaarjukka Demonspawn", 15000, 111, new ImpRace()),
            new StoreOwner("Gelaraldor the Herbmaster", 10000, 111, new HighElfRace()),
            new StoreOwner("Olelaldan the Wise", 10000, 110, new TchoTchoRace()),
            new StoreOwner("Fthoglo the Demonicist", 15000, 116, new ImpRace()),
            new StoreOwner("Dridash the Alchemist", 15000, 111, new HalfOrcRace())
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

        public override bool ItemMatches(Item item)
        {
            switch (item.BaseItemCategory)
            {
                case ScrollItemClass _:
                case PotionItemClass _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override IStoreCommand AdvertisedStoreCommand4 => new RestorationStoreCommand();
    }
}
