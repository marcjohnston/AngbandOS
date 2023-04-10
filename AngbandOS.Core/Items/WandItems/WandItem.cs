namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class WandItem : Item
    {
        public WandItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PercentageBreakageChance => 25;
        public override int? GetBonusRealValue(int value)
        {
            return value / 20 * TypeSpecificValue;
        }

    }
}