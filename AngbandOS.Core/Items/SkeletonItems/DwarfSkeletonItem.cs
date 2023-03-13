namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DwarfSkeletonItem : SkeletonItem
    {
        public DwarfSkeletonItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SkeletonDwarfSkeleton>()) { }
    }
}