using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletAntiTheft : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Anti-Theft";

        public override bool AntiTheft => true;
        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override string FriendlyName => "Anti-Theft";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int Weight => 3;
    }
}
