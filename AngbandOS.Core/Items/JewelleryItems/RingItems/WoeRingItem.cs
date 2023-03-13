namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WoeRingItem : RingItem
    {
        public WoeRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingWoe>()) { }
    }
}