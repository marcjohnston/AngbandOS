namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents armour items.  Boots, cloaks, crowns, dragon armour, gloves, hard armour, helm, shield and soft armour are all armour classes.
    /// </summary>
    internal abstract class ArmourItemClass : ItemFactory
    {
        public ArmourItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool HasQuality => true;

        public override int RandartActivationChance => base.RandartActivationChance * 2;
        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (item.RareItemTypeIndex != 0)
            {
                return 0;
            }
            if (cost <= 10)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 100)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }

        /// <summary>
        /// Returns true, for all armour where the armour class (ToA) is greater than or equal to zero.
        /// </summary>
        public override bool KindIsGood => ToA >= 0;

        public override bool IsWorthless(Item item)
        {
            if (item.TypeSpecificValue < 0)
            {
                return true;
            }
            if (item.BonusArmourClass < 0)
            {
                return true;
            }
            return false;
        }


        public override string GetDetailedDescription(Item item)
        {
            string s = "";
            if (item.IsKnown())
            {
                item.RefreshFlagBasedProperties();
                if (ShowMods || item.BonusToHit != 0 && item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";
                }
                else if (item.BonusToHit != 0)
                {
                    s += $" ({GetSignedValue(item.BonusToHit)})";
                }
                else if (item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusDamage)})";
                }

                // Add base armour class for all types of armour and when the base armour class is greater than zero.
                s += $" [{item.BaseArmourClass},{GetSignedValue(item.BonusArmourClass)}]";
            }
            else if (item.BaseArmourClass != 0)
            {
                s += $" [{item.BaseArmourClass}]";
            }
            return s;
        }
    }
}
