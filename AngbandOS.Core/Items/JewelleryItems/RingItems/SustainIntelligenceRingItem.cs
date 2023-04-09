namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SustainIntelligenceRingItem : RingItem
    {
        public SustainIntelligenceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSustainIntelligence>()) { }
    }
}