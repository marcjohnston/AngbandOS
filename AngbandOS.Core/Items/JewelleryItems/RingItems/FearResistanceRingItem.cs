namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FearResistanceRingItem : RingItem
    {
        public FearResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingFearResistance>()) { }
        public override bool EasyKnow => true;
        public override bool ResFear => true;
    }
}