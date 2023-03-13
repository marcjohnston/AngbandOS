namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TrapDetectionScrollItem : ScrollItem
    {
        public TrapDetectionScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollTrapDetection>()) { }
    }
}