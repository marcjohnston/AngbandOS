namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FlamesRingItem : RingItem
    {
        public FlamesRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingFlames>()) { }
    }
}