namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ObjectDetectionScrollItem : ScrollItem
    {
        public ObjectDetectionScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollObjectDetection>()) { }
    }
}