namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TulkasRingItem : RingItem
    {
        public TulkasRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingTulkas>()) { }
    }
}