namespace AngbandOS.Core.Items
{
[Serializable]
    internal class IceRingItem : RingItem
    {
        public IceRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingIce>()) { }
        public override bool Activate => true;
        public override bool IgnoreCold => true;
        public override bool ResCold => true;
    }
}