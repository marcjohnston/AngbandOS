namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HolyPrayerScrollItem : ScrollItem
    {
        public HolyPrayerScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollHolyPrayer>()) { }
    }
}