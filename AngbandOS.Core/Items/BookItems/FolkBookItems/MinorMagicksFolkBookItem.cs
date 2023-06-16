namespace AngbandOS.Core.Items;

[Serializable]
internal class MinorMagicksFolkBookItem : FolkBookItem
{
    public MinorMagicksFolkBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<MinorMagicksFolkBookItemFactory>()) { }
}