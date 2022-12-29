namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents jewellery items.  Amulets and rings are both armour classes.
    /// </summary>
    internal abstract class JewelleryItemClass : ItemClass
    {
        public JewelleryItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool IsStompable(Item item)
        {
            if (item.BonusDamage < 0 || item.BonusArmourClass < 0 || item.BonusToHit < 0 || item.TypeSpecificValue < 0)
            {
                return true;
            }
            return base.IsStompable(item);
        }
        public override bool CanAbsorb(Item item, Item other)
        {
            if (!item.IsKnown() || !other.IsKnown())
            {
                return false;
            }
            if (!item.StatsAreSame(other))
            {
                return false;
            }
            return true;
        }

        public override int? GetBonusRealValue(Item item, int value)
        {
            if (item.BonusArmourClass < 0 || item.BonusToHit < 0 || item.BonusDamage < 0)
                return 0;

            return (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
        }

        public override int? GetTypeSpecificRealValue(Item item, int value)
        {
            return ComputeTypeSpecificRealValue(item, value);
        }

        public override bool IsWorthless(Item item)
        {
            if (item.TypeSpecificValue < 0 || item.BonusArmourClass < 0 || item.BonusToHit < 0 || item.BonusDamage < 0)
            {
                return true;
            }
            return false;
        }
    }
}
