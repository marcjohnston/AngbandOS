namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WoeRingItem : RingItem
    {
        public WoeRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingWoe>()) { }
        public override bool Cha => true;
        public override bool Cursed => true;
        public override bool HideType => true;
        public override bool Teleport => true;
        public override bool Wis => true;
    }
}