namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordExecutionersSword : SwordItemClass
    {
        private SwordExecutionersSword(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '|';
        public override Colour Colour => Colour.Red;
        public override string Name => "Executioner's Sword";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 850;
        public override int Dd => 4;
        public override int Ds => 5;
        public override string FriendlyName => "& Executioner's Sword~";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 28;
        public override int Weight => 260;
        public override Item CreateItem() => new ExecutionersSwordWeaponItem(SaveGame);
    }
}
