namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SkeletonItem : Item
    {
        public SkeletonItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 40;
        public override int PercentageBreakageChance => 50;
    }
}