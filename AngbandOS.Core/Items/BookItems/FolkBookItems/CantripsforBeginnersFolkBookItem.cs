namespace AngbandOS.Core.Items;

[Serializable]
internal class CantripsforBeginnersFolkBookItem : FolkBookItem
{
    public CantripsforBeginnersFolkBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CantripsforBeginnersFolkBookItemFactory>()) { }
}