namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletReflection : AmuletItemClass
    {
        private AmuletReflection(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Reflection";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 30000;
        public override string FriendlyName => "Reflection";
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 0, 0, 0 };
        public override int Weight => 3;
        public override Item CreateItem(SaveGame saveGame) => new ReflectionAmuletItem(saveGame);
    }
}
