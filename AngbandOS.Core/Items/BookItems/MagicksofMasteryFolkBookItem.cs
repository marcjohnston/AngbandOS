namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MagicksofMasteryFolkBookItem : FolkBookItem
    {
        public MagicksofMasteryFolkBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<FolkBookMagicksofMastery>()) { }
    }
}