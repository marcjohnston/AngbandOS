namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BookOfCommonPrayerLifeBookItem : LifeBookItem
    {
        public BookOfCommonPrayerLifeBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LifeBookBookofCommonPrayer>()) { }
    }
}