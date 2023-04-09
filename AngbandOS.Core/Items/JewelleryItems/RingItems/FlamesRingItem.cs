namespace AngbandOS.Core.Items
{
[Serializable]
    internal class FlamesRingItem : RingItem
    {
        public FlamesRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingFlames>()) { }
        public override bool Activate => true;
        public override bool IgnoreFire => true;
        public override bool ResFire => true;
    }
}