namespace AngbandOS.Core.Items;

[Serializable]
internal class BrokenSkullSkeletonItem : SkeletonItem
{
    public BrokenSkullSkeletonItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SkeletonBrokenSkull>()) { }
}