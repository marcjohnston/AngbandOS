namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RechargingScrollItem : ScrollItem
    {
        public RechargingScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollRecharging>()) { }
    }
}