namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpeedRingItem : RingItem
    {
        public SpeedRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSpeed>()) { }
    }
}