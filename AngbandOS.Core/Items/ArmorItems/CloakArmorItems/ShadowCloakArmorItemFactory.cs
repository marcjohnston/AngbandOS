namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ShadowCloakArmorItemFactory : CloakArmorItemFactory
    {
        private ShadowCloakArmorItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '(';
        public override Colour Colour => Colour.Black;
        public override string Name => "Shadow Cloak";

        public override int Ac => 6;
        public override int[] Chance => new int[] { 5, 0, 0, 0 };
        public override int Cost => 7500;
        public override string FriendlyName => "& Shadow Cloak~";
        public override int Level => 60;
        public override int[] Locale => new int[] { 75, 0, 0, 0 };
        public override bool ResDark => true;
        public override bool ResLight => true;
        public override int? SubCategory => 6;
        public override int ToA => 4;
        public override int Weight => 5;
        public override Item CreateItem() => new ShadowCloakArmorItem(SaveGame);
    }
}
