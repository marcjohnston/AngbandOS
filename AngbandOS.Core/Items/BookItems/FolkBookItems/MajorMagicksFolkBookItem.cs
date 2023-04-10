namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MajorMagicksFolkBookItem : DeathBookItem
    {
        public MajorMagicksFolkBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<FolkBookMajorMagicks>()) { }
    }
}