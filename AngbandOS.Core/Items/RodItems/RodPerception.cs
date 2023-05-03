namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodPerception : RodItemFactory
    {
        private RodPerception(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Perception";

        public override int[] Chance => new int[] { 8, 8, 0, 0 };
        public override int Cost => 13000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Perception";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 100, 0, 0 };
        public override int? SubCategory => 2;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            zapRodEvent.Identified = true;
            if (!SaveGame.IdentifyItem())
            {
                zapRodEvent.UseCharge = false;
            }
            zapRodEvent.Item.TypeSpecificValue = 10;
        }
        public override Item CreateItem() => new PerceptionRodItem(SaveGame);
    }
}
