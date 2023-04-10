namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BottleItem : Item
    {
        public BottleItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PercentageBreakageChance => 100;
    }
}