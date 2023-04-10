namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodLight : RodItemClass
    {
        private RodLight(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Light";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Light";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 15;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            SaveGame.MsgPrint("A line of blue shimmering light appears.");
            SaveGame.LightLine(zapRodEvent.Dir.Value);
            zapRodEvent.Identified = true;
            zapRodEvent.Item.TypeSpecificValue = 9;
        }
        public override Item CreateItem() => new LightRodItem(SaveGame);
    }
}
