namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ElfSkeletonItem : SkeletonItem
    {
        public ElfSkeletonItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SkeletonElfSkeleton>()) { }
    }
}