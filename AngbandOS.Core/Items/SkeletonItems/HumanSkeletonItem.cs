namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HumanSkeletonItem : SkeletonItem
    {
        public HumanSkeletonItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SkeletonHumanSkeleton>()) { }
    }
}