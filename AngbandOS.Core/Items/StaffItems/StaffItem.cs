namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class StaffItem : Item
    {
        public StaffItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int? GetBonusRealValue(int value)
        {
            return value / 20 * TypeSpecificValue;
        }
        protected override bool FactoryCanAbsorbItem(Item other)
        {
            if (!IsKnown() || !other.IsKnown())
            {
                return false;
            }
            if (TypeSpecificValue != other.TypeSpecificValue)
            {
                return false;
            }
            return true;
        }
    }
}