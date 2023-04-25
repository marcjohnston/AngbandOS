namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DetectionRodItem : RodItem
    {
        public DetectionRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodDetection>()) { }
    }
}