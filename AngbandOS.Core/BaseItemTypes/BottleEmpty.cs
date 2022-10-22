namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class BottleEmpty : BottleItemCategory
    {
        public override char Character => '!';
        public override string Name => "Empty Bottle";

        public override int Chance1 => 1;
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Empty Bottle~";
        public override int? SubCategory => 1;
        public override int Weight => 2;
    }
}
