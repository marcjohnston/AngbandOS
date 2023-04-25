namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TrapDetectionScrollItem : ScrollItem
    {
        public TrapDetectionScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ScrollTrapDetection>()) { }
    }
}