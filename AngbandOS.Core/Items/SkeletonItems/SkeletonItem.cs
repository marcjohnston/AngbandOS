namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SkeletonItem : Item
    {
        public SkeletonItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}