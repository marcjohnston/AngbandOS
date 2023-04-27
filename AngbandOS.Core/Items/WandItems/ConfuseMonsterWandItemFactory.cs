namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ConfuseMonsterWandItemFactory : WandItemFactory
    {
        private ConfuseMonsterWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Confuse Monster";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Confuse Monster";
        public override int Level => 5;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int? SubCategory => WandType.ConfuseMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.ConfuseMonster(dir, 10);
        }
        public override Item CreateItem() => new ConfuseMonsterWandItem(SaveGame);
    }
}
