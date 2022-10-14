using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletAdornment : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Amulet:Adornment";

        public override int Chance1 => 1;
        public override int Cost => 20;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Adornment";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int? SubCategory => AmuletType.Adornment;
        public override int Weight => 3;
    }
}
