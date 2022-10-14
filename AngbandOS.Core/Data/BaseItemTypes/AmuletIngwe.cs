using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletIngwe : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Amulet:Amulet*";

        public override int Cost => 90000;
        public override string FriendlyName => "& Amulet~";
        public override bool InstaArt => true;
        public override int Level => 60;
        public override int? SubCategory => AmuletType.Ingwe;
        public override int Weight => 3;
    }
}
