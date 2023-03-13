namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlowDigestionRingItem : RingItem
    {
        public SlowDigestionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSlowDigestion>()) { }
    }
}