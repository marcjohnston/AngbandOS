using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletReflection : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Reflection";

        public override int Chance1 => 4;
        public override int Cost => 30000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Reflection";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 60;
        public override int Locale1 => 60;
        public override bool Reflect => true;
        public override int Weight => 3;
    }
}
