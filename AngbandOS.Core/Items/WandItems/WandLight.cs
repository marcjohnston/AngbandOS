namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandLight : WandItemClass
    {
        private WandLight(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Light";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Light";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int? SubCategory => WandType.Light;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.MsgPrint("A line of blue shimmering light appears.");
            saveGame.LightLine(dir);
            return true;
        }
        public override Item CreateItem() => new LightWandItem(SaveGame);
    }
}