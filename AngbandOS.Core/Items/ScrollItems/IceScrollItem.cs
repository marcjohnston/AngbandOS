namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IceScrollItem : ScrollItem
    {
        public IceScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollIce>()) { }
    }
}