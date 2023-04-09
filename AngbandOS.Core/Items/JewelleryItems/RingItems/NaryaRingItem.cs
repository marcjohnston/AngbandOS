namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NaryaRingItem : RingItem
    {
        public NaryaRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingNarya>()) { }
        public override bool InstaArt => true;
    }
}