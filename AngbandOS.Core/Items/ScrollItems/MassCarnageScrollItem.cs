namespace AngbandOS.Core.Items
{
[Serializable]
    internal class MassCarnageScrollItem : ScrollItem
    {
        public MassCarnageScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollMassCarnage>()) { }
    }
}