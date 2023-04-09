namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BarahirRingItem : RingItem
    {
        public BarahirRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingBarahir>()) { }
        public override bool InstaArt => true;
    }
}