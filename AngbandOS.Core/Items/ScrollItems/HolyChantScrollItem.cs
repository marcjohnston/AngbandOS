namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HolyChantScrollItem : ScrollItem
    {
        public HolyChantScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollHolyChant>()) { }
    }
}