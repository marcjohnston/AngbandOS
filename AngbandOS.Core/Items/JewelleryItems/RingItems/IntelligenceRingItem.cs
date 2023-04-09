namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IntelligenceRingItem : RingItem
    {
        public IntelligenceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingIntelligence>()) { }
        public override bool HideType => true;
        public override bool Int => true;
    }
}