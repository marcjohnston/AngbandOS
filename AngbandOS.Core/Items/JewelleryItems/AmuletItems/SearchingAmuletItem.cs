namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SearchingAmuletItem : AmuletItem
    {
        public SearchingAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletSearching>()) { }
    }
}