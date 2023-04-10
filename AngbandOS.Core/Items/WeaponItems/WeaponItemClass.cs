namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents weapon items.  Arrow, bolt, bow, digging, hafted, polearm, shot and swords are all weapon classes.
    /// </summary>
    internal abstract class WeaponItemClass : ItemFactory
    {
        public WeaponItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool HasQuality => true;


        /// <summary>
        /// Returns true, for all weapons where both the hit (ToH) and damage (ToD) are equal to or greater than zero.  False, for all weapons with either stat less than 0.
        /// </summary>
        public override bool KindIsGood
        {
            get
            {
                if (ToH < 0)
                {
                    return false;
                }
                if (ToD < 0)
                {
                    return false;
                }
                return true;
            }
        }

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

        public override bool CanApplySlayingBonus => true;

        public override string GetDetailedDescription(Item item)
        {
            string s = "";
            s += $" ({item.DamageDice}d{item.DamageDiceSides})";
            if (item.IsKnown())
            {
                s += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";

                if (item.BaseArmourClass != 0)
                {
                    // Add base armour class for all types of armour and when the base armour class is greater than zero.
                    s += $" [{item.BaseArmourClass},{GetSignedValue(item.BonusArmourClass)}]";
                }
                else if (item.BonusArmourClass != 0)
                {
                    // This is not armour, only show bonus armour class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.BonusArmourClass)}]";
                }
            }
            else if (item.BaseArmourClass != 0)
            {
                s += $" [{item.BaseArmourClass}]";
            }
            return s;
        }

        public override bool CanApplyTunnelBonus => true;

        public override int? GetTypeSpecificRealValue(Item item, int value)
        {
            return ComputeTypeSpecificRealValue(item, value);
        }

        public override bool IsWorthless(Item item)
        {
            if (item.TypeSpecificValue < 0)
            {
                return true;
            }
            if (item.BonusToHit + item.BonusDamage < 0)
            {
                return true;
            }
            return false;
        }
    }
}
