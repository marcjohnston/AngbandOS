namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SustainWisdomRingItem : RingItem
    {
        public SustainWisdomRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSustainWisdom>()) { }
    }
}