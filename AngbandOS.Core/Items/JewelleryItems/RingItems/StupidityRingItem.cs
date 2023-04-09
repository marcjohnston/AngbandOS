namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StupidityRingItem : RingItem
    {
        public StupidityRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingStupidity>()) { }
        public override bool Cursed => true;
        public override bool HideType => true;
        public override bool Int => true;
    }
}