namespace AngbandOS.Core.Items;

[Serializable]
internal class BrokenBoneSkeletonItem : SkeletonItem
{
    public BrokenBoneSkeletonItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SkeletonBrokenBone>()) { }
}