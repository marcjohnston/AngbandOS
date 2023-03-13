namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BrokenSkullSkeletonItem : SkeletonItem
    {
        public BrokenSkullSkeletonItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<SkeletonBrokenSkull>()) { }
    }
}