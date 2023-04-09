namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class StaffItem : Item
    {
        public StaffItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 15;
        public override int? GetBonusRealValue(Item item, int value)
        {
            return value / 20 * item.TypeSpecificValue;
        }
    }
}