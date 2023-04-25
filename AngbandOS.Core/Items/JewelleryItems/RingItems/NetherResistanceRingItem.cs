namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NetherResistanceRingItem : RingItem
    {
        public NetherResistanceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingNetherResistance>()) { }
    }
}