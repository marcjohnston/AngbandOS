namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TeleportationAmuletItem : AmuletItem
    {
        public TeleportationAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletTeleportation>()) { }
        public override bool Cursed => true;
        public override bool EasyKnow => true;
        public override bool Teleport => true;
    }
}