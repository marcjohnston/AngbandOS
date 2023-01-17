namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodDrainLife : RodItemClass
    {
        private RodDrainLife(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => true;
        public override char Character => '-';
        public override string Name => "Drain Life";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 3600;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Drain Life";
        public override int Level => 75;
        public override int[] Locale => new int[] { 75, 0, 0, 0 };
        public override int? SubCategory => 18;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            if (SaveGame.DrainLife(zapRodEvent.Dir.Value, 75))
            {
                zapRodEvent.Identified = true;
            }
            zapRodEvent.Item.TypeSpecificValue = 23;
        }
    }
}
