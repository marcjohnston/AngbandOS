namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NaryaRingItem : RingItem
    {
        public NaryaRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingNarya>()) { }
    }
}