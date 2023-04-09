namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DiggingOrcishPick : DiggingItemClass
    {
        private DiggingOrcishPick(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '\\';
        public override Colour Colour => Colour.Green;
        public override string Name => "Orcish Pick";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Orcish Pick~";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int Pval => 2;
        public override int Weight => 150;
        public override Item CreateItem(SaveGame saveGame) => new OrcishPickDiggingWeaponItem(saveGame);
    }
}
