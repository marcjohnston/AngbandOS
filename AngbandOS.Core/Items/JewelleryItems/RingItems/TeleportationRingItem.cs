namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportationRingItem : RingItem
    {
        public TeleportationRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingTeleportation>()) { }
        public override bool Cursed => true;
        public override bool EasyKnow => true;
        public override bool Teleport => true;
    }
}