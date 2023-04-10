namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandCloneMonster : WandItemClass
    {
        private WandCloneMonster(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Clone Monster";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Clone Monster";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 50, 0, 0 };
        public override int? SubCategory => WandType.CloneMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.CloneMonster(dir);
        }
        public override Item CreateItem(SaveGame saveGame) => new CloneMonsterWandItem(saveGame);
    }
}
