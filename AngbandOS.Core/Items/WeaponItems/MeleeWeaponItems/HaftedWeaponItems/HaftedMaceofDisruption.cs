namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HaftedMaceOfDisruption : HaftedItemClass
    {
        private HaftedMaceOfDisruption(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '\\';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Mace of Disruption";

        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 4300;
        public override int Dd => 5;
        public override int Ds => 8;
        public override string FriendlyName => "& Mace~ of Disruption";
        public override int Level => 80;
        public override int[] Locale => new int[] { 80, 0, 0, 0 };
        public override bool ShowMods => true;
        public override bool SlayUndead => true;
        public override int? SubCategory => 20;
        public override int Weight => 400;
        public override Item CreateItem() => new MaceOfDisruptionHaftedWeaponItem(SaveGame);
    }
}
