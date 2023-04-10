namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandSlowMonster : WandItemClass
    {
        private WandSlowMonster(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Slow Monster";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slow Monster";
        public override int Level => 5;
        public override int[] Locale => new int[] { 2, 0, 0, 0 };
        public override int? SubCategory => WandType.SlowMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.SlowMonster(dir);
        }
        public override Item CreateItem() => new SlowMonsterWandItem(SaveGame);
    }
}
