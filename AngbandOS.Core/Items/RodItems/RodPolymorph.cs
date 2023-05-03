namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodPolymorph : RodItemFactory
    {
        private RodPolymorph(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Polymorph";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1200;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Polymorph";
        public override int Level => 35;
        public override int[] Locale => new int[] { 35, 0, 0, 0 };
        public override int? SubCategory => 19;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            if (SaveGame.PolyMonster(zapRodEvent.Dir.Value))
            {
                zapRodEvent.Identified = true;
            }
            zapRodEvent.Item.TypeSpecificValue = 25;
        }
        public override Item CreateItem() => new PolymorphRodItem(SaveGame);
    }
}
