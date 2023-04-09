namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlindnessResistanceRingItem : RingItem
    {
        public BlindnessResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingBlindnessResistance>()) { }
        public override bool EasyKnow => true;
        public override bool ResBlind => true;
    }
}