namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CarnageScrollItem : ScrollItem
    {
        public CarnageScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollCarnage>()) { }
    }
}