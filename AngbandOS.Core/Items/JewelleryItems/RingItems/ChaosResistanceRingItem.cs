namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ChaosResistanceRingItem : RingItem
    {
        public ChaosResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingChaosResistance>()) { }
    }
}