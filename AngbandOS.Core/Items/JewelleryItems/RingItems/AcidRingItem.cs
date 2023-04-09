namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AcidRingItem : RingItem
    {
        public AcidRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingAcid>()) { }
        public override bool Activate => true;
        public override bool IgnoreAcid => true;
        public override bool ResAcid => true;
    }
}