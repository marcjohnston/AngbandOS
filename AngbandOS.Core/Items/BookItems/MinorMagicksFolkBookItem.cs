namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MinorMagicksFolkBookItem : DeathBookItem
    {
        public MinorMagicksFolkBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<FolkBookMinorMagicks>()) { }
    }
}