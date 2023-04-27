namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolymorphWandItemFactory : WandItemFactory
    {
        private PolymorphWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Polymorph";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Polymorph";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => WandType.Polymorph;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.PolyMonster(dir);
        }
        public override Item CreateItem() => new PolymorphWandItem(SaveGame);
    }
}
