namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CommonPrayerLifeBookItem : LifeBookItem
    {
        public CommonPrayerLifeBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CommonPrayerLifeBookItemFactory>()) { }
    }
}