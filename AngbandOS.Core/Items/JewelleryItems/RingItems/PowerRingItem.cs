namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PowerRingItem : RingItem
    {
        public PowerRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingPower>()) { }
    }
}