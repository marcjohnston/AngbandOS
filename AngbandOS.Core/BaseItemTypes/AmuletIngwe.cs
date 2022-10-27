using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletIngwe : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Ingwe";

        public override int Cost => 90000;
        public override string FriendlyName => "& Amulet~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 60;
        public override int Weight => 3;
    }
}
