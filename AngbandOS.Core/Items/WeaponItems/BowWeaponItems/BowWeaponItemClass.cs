namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class BowWeaponItemClass : WeaponItemClass // TODO: Should be renamed to RangedWeaponItemClass
    {
        public BowWeaponItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<RangedWeaponInventorySlot>();
        /// <summary>
        /// Returns a damage multiplier when the missile weapon is used.
        /// </summary>
        public virtual int MissileDamageMultiplier => 1;
        public override int? SubCategory => null; // The subcategory for all bows have been resolved.

        public override int PackSort => 32;
        public abstract ItemTypeEnum AmmunitionItemCategory { get; }

        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bow;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;
        public override string GetDetailedDescription(Item item)
        {
            string basenm = "";
            item.RefreshFlagBasedProperties();
            int power = item.ItemSubCategory % 10;
            if (XtraMight)
            {
                power++;
            }
            basenm += $" (x{power})";
            if (item.IsKnown())
            {
                basenm += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";

                if (item.BaseArmourClass != 0)
                {
                    // Add base armour class for all types of armour and when the base armour class is greater than zero.
                    basenm += $" [{item.BaseArmourClass},{GetSignedValue(item.BonusArmourClass)}]";
                }
                else if (item.BonusArmourClass != 0)
                {
                    // This is not armour, only show bonus armour class, if it is not zero and we know about it.
                    basenm += $" [{GetSignedValue(item.BonusArmourClass)}]";
                }
            }
            else if (item.BaseArmourClass != 0)
            {
                basenm += $" [{item.BaseArmourClass}]";
            }
            return basenm;
        }


        public override Colour Colour => Colour.Brown;
    }
}
