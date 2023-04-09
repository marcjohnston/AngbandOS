namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IceRingItem : RingItem
    {
        public IceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingIce>()) { }
    }
}