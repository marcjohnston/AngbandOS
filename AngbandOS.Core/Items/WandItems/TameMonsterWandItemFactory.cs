namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class TameMonsterWandItemFactory : WandItemFactory
    {
        private TameMonsterWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Tame Monster";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Tame Monster";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => WandType.CharmMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.CharmMonster(dir, 45);
        }
        public override Item CreateItem() => new TameMonsterWandItem(SaveGame);
    }
}
