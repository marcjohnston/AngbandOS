namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DOOMAmuletItem : AmuletItem
    {
        public DOOMAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletDOOM>()) { }
        public override bool Cha => true;
        public override bool Con => true;
        public override bool Cursed => true;
        public override bool Dex => true;
        public override bool HideType => true;
        public override bool Int => true;
        public override bool Str => true;
        public override bool Wis => true;
    }
}