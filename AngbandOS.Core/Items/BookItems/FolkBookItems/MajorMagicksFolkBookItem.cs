namespace AngbandOS.Core.Items;

[Serializable]
internal class MajorMagicksFolkBookItem : FolkBookItem
{
    public MajorMagicksFolkBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<MajorMagicksFolkBookItemFactory>()) { }
}