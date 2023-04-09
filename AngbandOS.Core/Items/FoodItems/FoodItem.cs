namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class FoodItem : Item
    {
        public FoodItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 9;
        public override int PercentageBreakageChance => 100;
    }
}