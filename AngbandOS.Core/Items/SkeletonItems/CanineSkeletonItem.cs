namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CanineSkeletonItem : SkeletonItem
    {
        public CanineSkeletonItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SkeletonCanineSkeleton>()) { }
    }
}