namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class AmuletNecklace : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Amulet:Necklace";

        public override int Cost => 75000;
        public override string FriendlyName => "& Necklace~";
        public override bool InstaArt => true;
        public override int Level => 70;
        public override int SubCategory => 12;
        public override int Weight => 3;
    }
}
