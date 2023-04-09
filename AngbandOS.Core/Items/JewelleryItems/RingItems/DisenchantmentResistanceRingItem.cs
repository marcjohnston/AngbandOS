namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DisenchantmentResistanceRingItem : RingItem
    {
        public DisenchantmentResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingDisenchantmentResistance>()) { }
        public override bool EasyKnow => true;
        public override bool ResDisen => true;
    }
}