namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LightAndDarknessResistancRingItem : RingItem
    {
        public LightAndDarknessResistancRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingLightAndDarknessResistanc>()) { }
        public override bool EasyKnow => true;
        public override bool ResDark => true;
        public override bool ResLight => true;
    }
}