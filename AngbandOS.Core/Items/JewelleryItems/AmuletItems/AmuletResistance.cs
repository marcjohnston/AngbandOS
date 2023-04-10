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
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override bool ResAcid => true;
        public override bool ResCold => true;
        public override bool ResElec => true;
        public override bool ResFire => true;
        public override int Weight => 3;
        public override bool KindIsGood => true;
        public override Item CreateItem() => new ResistanceAmuletItem(SaveGame);
    }
}
