namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class SkeletonItem : Item
{
    public SkeletonItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override int PercentageBreakageChance => 50;
}