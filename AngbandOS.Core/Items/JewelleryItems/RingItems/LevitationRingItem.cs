namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LevitationRingItem : RingItem
    {
        public LevitationRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LevitationRingItemFactory>()) { }
    }
}