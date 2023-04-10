namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingSustainConstitution : RingItemClass
    {
        private RingSustainConstitution(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Sustain Constitution";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 750;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Constitution";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 13;
        public override bool SustCon => true;
        public override int Weight => 2;
        public override Item CreateItem() => new SustainConstitutionRingItem(SaveGame);
    }
}
