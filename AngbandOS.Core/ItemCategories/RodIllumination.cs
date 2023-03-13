namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RodIllumination : RodItemClass
    {
        private RodIllumination(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool RequiresAiming => false;
        public override char Character => '-';
        public override string Name => "Illumination";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Illumination";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 4;
        public override int Weight => 15;
        public override void Execute(ZapRodEvent zapRodEvent)
        {
            if (SaveGame.LightArea(Program.Rng.DiceRoll(2, 8), 2))
            {
                zapRodEvent.Identified = true;
            }
            zapRodEvent.Item.TypeSpecificValue = 10 + Program.Rng.DieRoll(11);
        }
        public override Item CreateItem(SaveGame saveGame) => new IlluminationRodItem(saveGame);
    }
}
