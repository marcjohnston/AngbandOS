namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ConfusionResistanceRingItem : RingItem
    {
        public ConfusionResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingConfusionResistance>()) { }
        public override bool EasyKnow => true;
        public override bool ResConf => true;
    }
}