namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NexusResistanceRingItem : RingItem
    {
        public NexusResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingNexusResistance>()) { }
    }
}