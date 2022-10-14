using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletCarlammas : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Carlammas";

        public override int Cost => 60000;
        public override string FriendlyName => "& Amulet~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 50;
        public override int Weight => 3;
    }
}
