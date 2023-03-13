namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NenyaRingItem : RingItem
    {
        public NenyaRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingNenya>()) { }
    }
}