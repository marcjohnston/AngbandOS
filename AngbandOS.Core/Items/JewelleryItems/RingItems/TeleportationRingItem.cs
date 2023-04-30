namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportationRingItem : RingItem
    {
        public TeleportationRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<TeleportationRingItemFactory>()) { }
    }
}