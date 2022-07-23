using Cthangband.Commands;
using Cthangband.Enumerations;
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
                new ItemIdentifier(ItemCategory.Boots, BootsType.SvPairOfSoftLeatherBoots),
                new ItemIdentifier(ItemCategory.Boots, BootsType.SvPairOfSoftLeatherBoots),
                new ItemIdentifier(ItemCategory.Boots, BootsType.SvPairOfHardLeatherBoots),
                new ItemIdentifier(ItemCategory.Boots, BootsType.SvPairOfHardLeatherBoots),
                new ItemIdentifier(ItemCategory.Helm, HelmType.SvHardLeatherCap),
                new ItemIdentifier(ItemCategory.Helm, HelmType.SvHardLeatherCap),
                new ItemIdentifier(ItemCategory.Helm, HelmType.SvMetalCap),
                new ItemIdentifier(ItemCategory.Helm, HelmType.SvIronHelm),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvRobe),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvRobe),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvSoftLeatherArmor),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvSoftLeatherArmor),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvHardLeatherArmor),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvHardLeatherArmor),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvHardStuddedLeather),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvHardStuddedLeather),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvLeatherScaleMail),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvLeatherScaleMail),
                new ItemIdentifier(ItemCategory.HardArmor, HardArmourType.SvMetalScaleMail),
                new ItemIdentifier(ItemCategory.HardArmor, HardArmourType.SvChainMail),
                new ItemIdentifier(ItemCategory.HardArmor, HardArmourType.SvChainMail),
                new ItemIdentifier(ItemCategory.HardArmor, HardArmourType.SvAugmentedChainMail),
                new ItemIdentifier(ItemCategory.HardArmor, HardArmourType.SvBarChainMail),
                new ItemIdentifier(ItemCategory.HardArmor, HardArmourType.SvDoubleChainMail),
                new ItemIdentifier(ItemCategory.HardArmor, HardArmourType.SvMetalBrigandineArmor),
                new ItemIdentifier(ItemCategory.Gloves, GlovesType.SvSetOfLeatherGloves),
                new ItemIdentifier(ItemCategory.Gloves, GlovesType.SvSetOfLeatherGloves),
                new ItemIdentifier(ItemCategory.Gloves, GlovesType.SvSetOfGauntlets),
                new ItemIdentifier(ItemCategory.Shield, ShieldType.SvSmallLeatherShield),
                new ItemIdentifier(ItemCategory.Shield, ShieldType.SvSmallLeatherShield),
                new ItemIdentifier(ItemCategory.Shield, ShieldType.SvLargeLeatherShield),
                new ItemIdentifier(ItemCategory.Shield, ShieldType.SvSmallMetalShield),
                new ItemIdentifier(ItemCategory.Boots, BootsType.SvPairOfHardLeatherBoots),
                new ItemIdentifier(ItemCategory.Boots, BootsType.SvPairOfHardLeatherBoots),
                new ItemIdentifier(ItemCategory.Helm, HelmType.SvHardLeatherCap),
                new ItemIdentifier(ItemCategory.Helm, HelmType.SvHardLeatherCap),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvRobe),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvSoftLeatherArmor),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvSoftLeatherArmor),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvHardLeatherArmor),
                new ItemIdentifier(ItemCategory.SoftArmor, SoftArmourType.SvLeatherScaleMail),
                new ItemIdentifier(ItemCategory.HardArmor, HardArmourType.SvMetalScaleMail),
                new ItemIdentifier(ItemCategory.HardArmor, HardArmourType.SvChainMail),
                new ItemIdentifier(ItemCategory.HardArmor, HardArmourType.SvChainMail),
                new ItemIdentifier(ItemCategory.Gloves, GlovesType.SvSetOfLeatherGloves),
                new ItemIdentifier(ItemCategory.Gloves, GlovesType.SvSetOfGauntlets),
                new ItemIdentifier(ItemCategory.Shield, ShieldType.SvSmallLeatherShield),
                new ItemIdentifier(ItemCategory.Shield, ShieldType.SvSmallLeatherShield)
            };
        }

        protected override bool StoreWillBuy(Item item)
        {
            switch (item.Category)
            {
                case ItemCategory.Boots:
                case ItemCategory.Gloves:
                case ItemCategory.Crown:
                case ItemCategory.Helm:
                case ItemCategory.Shield:
                case ItemCategory.Cloak:
                case ItemCategory.SoftArmor:
                case ItemCategory.HardArmor:
                case ItemCategory.DragArmor:
                    return item.Value() > 0;
                default:
                    return false;
            }
        }
        protected override IStoreCommand AdvertisedStoreCommand4 => new EnchantWeaponStoreCommand();
    }
}
