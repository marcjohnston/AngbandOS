using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.ItemCategories;
using Cthangband.StoreCommands;
using System;

namespace Cthangband.Stores
{
    [Serializable]
    internal class ArmouryStore : Store
    {
        public ArmouryStore() : base(StoreType.StoreArmoury)
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

        protected override ItemIdentifier[] GetStoreTable()
        {
            return new[]
            {
                new ItemIdentifier(typeof(BootsSoftLeatherBoots)),
                new ItemIdentifier(typeof(BootsSoftLeatherBoots)),
                new ItemIdentifier(typeof(BootsHardLeatherBoots)),
                new ItemIdentifier(typeof(BootsHardLeatherBoots)),
                new ItemIdentifier(typeof(HelmHardLeatherCap)),
                new ItemIdentifier(typeof(HelmHardLeatherCap)),
                new ItemIdentifier(typeof(HelmMetalCap)),
                new ItemIdentifier(typeof(HelmIronHelm)),
                new ItemIdentifier(typeof(SoftArmorRobe)),
                new ItemIdentifier(typeof(SoftArmorRobe)),
                new ItemIdentifier(typeof(SoftArmorSoftLeatherArmour)),
                new ItemIdentifier(typeof(SoftArmorSoftLeatherArmour)),
                new ItemIdentifier(typeof(SoftArmorHardLeatherArmour)),
                new ItemIdentifier(typeof(SoftArmorHardLeatherArmour)),
                new ItemIdentifier(typeof(SoftArmorHardStuddedLeather)),
                new ItemIdentifier(typeof(SoftArmorHardStuddedLeather)),
                new ItemIdentifier(typeof(SoftArmorLeatherScaleMail)),
                new ItemIdentifier(typeof(SoftArmorLeatherScaleMail)),
                new ItemIdentifier(typeof(HardArmorMetalScaleMail)),
                new ItemIdentifier(typeof(HardArmorChainMail)),
                new ItemIdentifier(typeof(HardArmorChainMail)),
                new ItemIdentifier(typeof(HardArmorAugmentedChainMail)),
                new ItemIdentifier(typeof(HardArmorBarChainMail)),
                new ItemIdentifier(typeof(HardArmorDoubleChainMail)),
                new ItemIdentifier(typeof(HardArmorMetalBrigandineArmour)),
                new ItemIdentifier(typeof(GlovesSetOfLeatherGloves)),
                new ItemIdentifier(typeof(GlovesSetOfLeatherGloves)),
                new ItemIdentifier(typeof(GlovesSetOfGauntlets)),
                new ItemIdentifier(typeof(ShieldSmallLeatherShield)),
                new ItemIdentifier(typeof(ShieldSmallLeatherShield)),
                new ItemIdentifier(typeof(ShieldLargeLeatherShield)),
                new ItemIdentifier(typeof(ShieldSmallMetalShield)),
                new ItemIdentifier(typeof(BootsHardLeatherBoots)),
                new ItemIdentifier(typeof(BootsHardLeatherBoots)),
                new ItemIdentifier(typeof(HelmHardLeatherCap)),
                new ItemIdentifier(typeof(HelmHardLeatherCap)),
                new ItemIdentifier(typeof(SoftArmorRobe)),
                new ItemIdentifier(typeof(SoftArmorSoftLeatherArmour)),
                new ItemIdentifier(typeof(SoftArmorSoftLeatherArmour)),
                new ItemIdentifier(typeof(SoftArmorHardLeatherArmour)),
                new ItemIdentifier(typeof(SoftArmorLeatherScaleMail)),
                new ItemIdentifier(typeof(HardArmorMetalScaleMail)),
                new ItemIdentifier(typeof(HardArmorChainMail)),
                new ItemIdentifier(typeof(HardArmorChainMail)),
                new ItemIdentifier(typeof(GlovesSetOfLeatherGloves)),
                new ItemIdentifier(typeof(GlovesSetOfGauntlets)),
                new ItemIdentifier(typeof(ShieldSmallLeatherShield)),
                new ItemIdentifier(typeof(ShieldSmallLeatherShield))
            };
        }

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.ItemType.BaseCategory)
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
        protected override IStoreCommand AdvertisedStoreCommand4 => new EnchantWeaponStoreCommand();
    }
}
