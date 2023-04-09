namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PoisonResistanceRingItem : RingItem
    {
        public PoisonResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingPoisonResistance>()) { }
        public override bool EasyKnow => true;
        public override bool ResPois => true;
    }
}