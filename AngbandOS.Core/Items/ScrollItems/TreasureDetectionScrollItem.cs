namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TreasureDetectionScrollItem : ScrollItem
    {
        public TreasureDetectionScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollTreasureDetection>()) { }
    }
}