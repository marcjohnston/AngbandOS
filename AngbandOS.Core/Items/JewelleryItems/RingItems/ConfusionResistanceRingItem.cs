namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ConfusionResistanceRingItem : RingItem
    {
        public ConfusionResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingConfusionResistance>()) { }
    }
}