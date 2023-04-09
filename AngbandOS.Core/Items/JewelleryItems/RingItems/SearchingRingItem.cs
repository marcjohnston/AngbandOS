namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SearchingRingItem : RingItem
    {
        public SearchingRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSearching>()) { }
        public override bool HideType => true;
        public override bool Search => true;
    }
}