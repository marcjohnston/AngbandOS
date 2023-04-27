namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandDrainLife : WandItemFactory
    {
        private WandDrainLife(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Drain Life";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1200;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Drain Life";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => WandType.DrainLife;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.DrainLife(dir, 75);
        }
        public override Item CreateItem() => new DrainLifeWandItem(SaveGame);
    }
}
