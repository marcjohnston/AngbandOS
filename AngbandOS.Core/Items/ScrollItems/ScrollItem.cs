namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ScrollItem : Item
    {
        public ScrollItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 12;
        public override int PercentageBreakageChance => 50;
    }
}