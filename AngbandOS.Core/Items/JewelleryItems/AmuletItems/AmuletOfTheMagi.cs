namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletOfTheMagi : AmuletItemClass
    {
        private AmuletOfTheMagi(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "the Magi";

        public override int[] Chance => new int[] { 4, 3, 0, 0 };
        public override int Cost => 30000;
        public override bool FreeAct => true;
        public override string FriendlyName => "the Magi";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 80, 0, 0 };
        public override bool Search => true;
        public override bool SeeInvis => true;
        public override int ToA => 3;
        public override int Weight => 3;

        public override bool KindIsGood => true;
        public override Item CreateItem() => new OfTheMagiAmuletItem(SaveGame);
    }
}
