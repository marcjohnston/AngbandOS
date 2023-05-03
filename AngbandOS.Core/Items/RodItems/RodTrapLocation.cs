namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodTrapLocation : RodItemFactory
    {
        private RodTrapLocation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Trap Location";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Trap Location";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 0;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            if (SaveGame.DetectTraps())
            {
                zapRodEvent.Identified = true;
            }
            zapRodEvent.Item.TypeSpecificValue = 10 + Program.Rng.DieRoll(10);
        }
        public override Item CreateItem() => new TrapLocationRodItem(SaveGame);
    }
}
