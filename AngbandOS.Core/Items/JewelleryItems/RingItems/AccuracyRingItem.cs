namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AccuracyRingItem : RingItem
    {
        public AccuracyRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingAccuracy>()) { }
    }
}