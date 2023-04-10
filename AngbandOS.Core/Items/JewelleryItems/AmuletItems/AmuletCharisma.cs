namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletCharisma : AmuletItemClass
    {
        private AmuletCharisma(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Charisma";

        public override bool Cha => true;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Charisma";
        public override bool HideType => true;
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int Weight => 3;

        public override Item CreateItem() => new CharismaAmuletItem(SaveGame);
    }
}
