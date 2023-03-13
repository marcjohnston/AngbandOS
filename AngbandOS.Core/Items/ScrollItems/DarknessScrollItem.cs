namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DarknessScrollItem : ScrollItem
    {
        public DarknessScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollDarkness>()) { }
    }
}