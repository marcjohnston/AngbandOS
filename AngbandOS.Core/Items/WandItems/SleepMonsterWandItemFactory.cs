namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandSleepMonster : WandItemClass
    {
        private WandSleepMonster(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Sleep Monster";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Sleep Monster";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => WandType.SleepMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.SleepMonster(dir);
        }
        public override Item CreateItem() => new SleepMonsterWandItem(SaveGame);
    }
}
