using AngbandOS.Commands;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.StoreCommands;
using System;

namespace AngbandOS.Stores
{
    [Serializable]
    internal class ArmouryStore : Store
    {
        public ArmouryStore(SaveGame saveGame) : base(saveGame, StoreType.StoreArmoury)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Kon-Dar the Ugly", 10000, 115, RaceId.HalfOrc),
            new StoreOwner("Darg-Low the Grim", 15000, 111, RaceId.Human),
            new StoreOwner("Decado the Handsome", 25000, 112, RaceId.Great),
            new StoreOwner("Elo Dragonscale", 30000, 112, RaceId.Elf),
            new StoreOwner("Delicatus", 10000, 115, RaceId.Sprite),
            new StoreOwner("Gruce the Huge", 15000, 111, RaceId.HalfGiant),
            new StoreOwner("Animus", 25000, 112, RaceId.Golem), new StoreOwner("Malvus", 30000, 112, RaceId.HalfTitan),
            new StoreOwner("Selaxis", 10000, 115, RaceId.Zombie),
            new StoreOwner("Deathchill", 15000, 111, RaceId.Spectre),
            new StoreOwner("Drios the Faint", 25000, 112, RaceId.Spectre),
            new StoreOwner("Bathric the Cold", 30000, 112, RaceId.Vampire),
            new StoreOwner("Vengella the Cruel", 10000, 115, RaceId.HalfTroll),
            new StoreOwner("Wyrana the Mighty", 15000, 111, RaceId.Human),
            new StoreOwner("Yojo II", 25000, 112, RaceId.Dwarf),
            new StoreOwner("Ranalar the Sweet", 30000, 112, RaceId.Great),
            new StoreOwner("Horbag the Unclean", 10000, 115, RaceId.HalfOrc),
            new StoreOwner("Elelen the Telepath", 15000, 111, RaceId.DarkElf),
            new StoreOwner("Isedrelias", 25000, 112, RaceId.Sprite),
            new StoreOwner("Vegnar One-eye", 30000, 112, RaceId.Cyclops),
            new StoreOwner("Rodish the Chaotic", 10000, 115, RaceId.MiriNigri),
            new StoreOwner("Hesin Swordmaster", 15000, 111, RaceId.Nibelung),
            new StoreOwner("Elvererith the Cheat", 25000, 112, RaceId.DarkElf),
            new StoreOwner("Zzathath the Imp", 30000, 112, RaceId.Imp)
        };

        public override string FeatureType => "Armoury";

        protected override StockStoreInventoryItem[] GetStoreTable()
        {
            return new[]
            {
                new StockStoreInventoryItem(typeof(BootsHardLeatherBoots), 4),
                new StockStoreInventoryItem(typeof(BootsSoftLeatherBoots), 2),
                new StockStoreInventoryItem(typeof(GlovesSetOfGauntlets), 2),
                new StockStoreInventoryItem(typeof(GlovesSetOfLeatherGloves), 3),
                new StockStoreInventoryItem(typeof(HardArmorAugmentedChainMail)),
                new StockStoreInventoryItem(typeof(HardArmorBarChainMail)),
                new StockStoreInventoryItem(typeof(HardArmorChainMail), 4),
                new StockStoreInventoryItem(typeof(HardArmorDoubleChainMail)),
                new StockStoreInventoryItem(typeof(HardArmorMetalBrigandineArmour)),
                new StockStoreInventoryItem(typeof(HardArmorMetalScaleMail), 2),
                new StockStoreInventoryItem(typeof(HelmHardLeatherCap), 4),
                new StockStoreInventoryItem(typeof(HelmIronHelm)),
                new StockStoreInventoryItem(typeof(HelmMetalCap)),
                new StockStoreInventoryItem(typeof(ShieldLargeLeatherShield)),
                new StockStoreInventoryItem(typeof(ShieldSmallLeatherShield), 4),
                new StockStoreInventoryItem(typeof(ShieldSmallMetalShield)),
                new StockStoreInventoryItem(typeof(SoftArmorHardLeatherArmour), 3),
                new StockStoreInventoryItem(typeof(SoftArmorHardStuddedLeather), 2),
                new StockStoreInventoryItem(typeof(SoftArmorLeatherScaleMail), 3),
                new StockStoreInventoryItem(typeof(SoftArmorRobe), 3),
                new StockStoreInventoryItem(typeof(SoftArmorSoftLeatherArmour), 4),
            };
        }

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.ItemType.BaseItemCategory)
            {
                case BootsItemCategory _:
                case GlovesItemCategory _:
                case CrownItemCategory _:
                case HelmItemCategory _:
                case ShieldItemCategory _:
                case CloakItemCategory _:
                case SoftArmorItemCategory _:
                case HardArmorItemCategory _:
                case DragArmorItemCategory _:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override IStoreCommand AdvertisedStoreCommand4 => new EnchantArmorStoreCommand();
    }
}
