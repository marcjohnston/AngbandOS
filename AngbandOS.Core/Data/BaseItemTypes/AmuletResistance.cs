namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletResistance : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Amulet:Resistance";

        public override int Chance1 => 4;
        public override int Cost => 25000;
        public override string FriendlyName => "Resistance";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override bool ResAcid => true;
        public override bool ResCold => true;
        public override bool ResElec => true;
        public override bool ResFire => true;
        public override int SubCategory => 15;
        public override int Weight => 3;
    }
}
