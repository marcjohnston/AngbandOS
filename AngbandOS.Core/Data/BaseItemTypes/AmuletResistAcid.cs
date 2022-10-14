using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletResistAcid : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Amulet:Resist Acid";

        public override int Chance1 => 1;
        public override int Cost => 300;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Resist Acid";
        public override bool IgnoreAcid => true;
        public override int Level => 20;
        public override int Locale1 => 20;
        public override bool ResAcid => true;
        public override int? SubCategory => AmuletType.ResistAcid;
        public override int Weight => 3;
    }
}
