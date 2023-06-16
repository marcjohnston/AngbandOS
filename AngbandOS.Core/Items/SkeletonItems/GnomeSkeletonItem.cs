namespace AngbandOS.Core.Items;

[Serializable]
internal class GnomeSkeletonItem : SkeletonItem
{
    public GnomeSkeletonItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SkeletonGnomeSkeleton>()) { }
}