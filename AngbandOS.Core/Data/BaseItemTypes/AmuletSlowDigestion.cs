using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletSlowDigestion : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Amulet:Slow Digestion";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Slow Digestion";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override bool SlowDigest => true;
        public override int? SubCategory => AmuletType.SlowDigest;
        public override int Weight => 3;
    }
}
