namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletResistance : AmuletItemClass
    {
        private AmuletResistance(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Resistance";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 25000;
        public override string FriendlyName => "Resistance";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int Weight => 3;

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (Program.Rng.DieRoll(3) == 1)
            {
                IArtifactBias? artifactBias = null;
                item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
            }
            if (Program.Rng.DieRoll(5) == 1)
            {
                item.RandartItemCharacteristics.ResPois = true;
            }
        }

        public override bool KindIsGood => true;
        public override Item CreateItem(SaveGame saveGame) => new ResistanceAmuletItem(saveGame);
    }
}
