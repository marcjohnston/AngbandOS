namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletSearching : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Amulet:Searching";

        public override int Chance1 => 4;
        public override int Cost => 600;
        public override string FriendlyName => "Searching";
        public override bool HideType => true;
        public override int Level => 30;
        public override int Locale1 => 30;
        public override bool Search => true;
        public override int SubCategory => 5;
        public override int Weight => 3;
    }
}
