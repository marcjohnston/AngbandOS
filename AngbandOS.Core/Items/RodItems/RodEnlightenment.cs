namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodEnlightenment : RodItemFactory
    {
        private RodEnlightenment(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Enlightenment";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 10000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Enlightenment";
        public override int Level => 65;
        public override int[] Locale => new int[] { 65, 0, 0, 0 };
        public override int? SubCategory => 5;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            SaveGame.Level.MapArea();
            zapRodEvent.Identified = true;
            zapRodEvent.Item.TypeSpecificValue = 99;
        }
        public override Item CreateItem() => new EnlightenmentRodItem(SaveGame);
    }
}
