namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class JewelleryItem : Item
    {
        public JewelleryItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int? GetBonusRealValue(int value)
        {
            if (BonusArmourClass < 0 || BonusToHit < 0 || BonusDamage < 0)
                return 0;

            return (BonusToHit + BonusDamage + BonusArmourClass) * 100;
        }
        protected override bool FactoryCanAbsorbItem(Item other)
        {
            if (!IsKnown() || !other.IsKnown())
            {
                return false;
            }
            if (!StatsAreSame(other))
            {
                return false;
            }
            return true;
        }

        public override int? GetTypeSpecificRealValue(int value)
        {
            return ComputeTypeSpecificRealValue(value);
        }
        public override bool IsStompable()
        {
            if (BonusDamage < 0 || BonusArmourClass < 0 || BonusToHit < 0 || TypeSpecificValue < 0)
            {
                return true;
            }
            return base.IsStompable();
        }
        public override bool IsWorthless()
        {
            if (TypeSpecificValue < 0 || BonusArmourClass < 0 || BonusToHit < 0 || BonusDamage < 0)
            {
                return true;
            }
            return false;
        }
    }
}