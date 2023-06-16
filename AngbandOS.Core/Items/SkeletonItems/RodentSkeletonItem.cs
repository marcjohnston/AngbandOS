namespace AngbandOS.Core.Items;

[Serializable]
internal class RodentSkeletonItem : SkeletonItem
{
    public RodentSkeletonItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SkeletonRodentSkeleton>()) { }
}