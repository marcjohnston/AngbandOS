namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DetectInvisibleScrollItem : ScrollItem
    {
        public DetectInvisibleScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollDetectInvisible>()) { }
    }
}