namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ShardResistanceRingItem : RingItem
    {
        public ShardResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingShardResistance>()) { }
    }
}