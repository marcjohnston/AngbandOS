namespace AngbandOS.Core.Items
{
[Serializable]
    internal class VilyaRingItem : RingItem
    {
        public VilyaRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingVilya>()) { }
    }
}