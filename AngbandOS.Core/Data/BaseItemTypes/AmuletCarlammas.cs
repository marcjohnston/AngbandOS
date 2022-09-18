namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletCarlammas : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Amulet:Amulet";

        public override int Cost => 60000;
        public override string FriendlyName => "& Amulet~";
        public override bool InstaArt => true;
        public override int Level => 50;
        public override int SubCategory => 10;
        public override int Weight => 3;
    }
}
