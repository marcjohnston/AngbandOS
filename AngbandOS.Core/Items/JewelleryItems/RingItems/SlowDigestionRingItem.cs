namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlowDigestionRingItem : RingItem
    {
        public SlowDigestionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSlowDigestion>()) { }
        public override bool EasyKnow => true;
        public override bool SlowDigest => true;
    }
}