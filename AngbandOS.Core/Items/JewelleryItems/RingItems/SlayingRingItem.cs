namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlayingRingItem : RingItem
    {
        public SlayingRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSlaying>()) { }
    }
}