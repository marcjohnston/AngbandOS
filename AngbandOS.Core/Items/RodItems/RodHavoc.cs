namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodHavoc : RodItemClass
    {
        private RodHavoc(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Havoc";

        public override int[] Chance => new int[] { 16, 0, 0, 0 };
        public override int Cost => 150000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Havoc";
        public override int Level => 95;
        public override int[] Locale => new int[] { 100, 0, 0, 0 };
        public override int? SubCategory => 28;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            SaveGame.CallChaos();
            zapRodEvent.Identified = true;
            zapRodEvent.Item.TypeSpecificValue = 250;
        }
        public override Item CreateItem() => new HavocRodItem(SaveGame);
    }
}
