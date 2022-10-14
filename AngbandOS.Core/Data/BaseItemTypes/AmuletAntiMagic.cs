using AngbandOS.Enumerations;
using AngbandOS.StaticData;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletAntiMagic : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Anti-Magic";

        public override int Chance1 => 4;
        public override int Cost => 30000;
        public override string FriendlyName => "Anti-Magic";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 40;
        public override int Locale1 => 40;
        public override bool NoMagic => true;
        public override int? SubCategory => AmuletType.NoMagic;
        public override int Weight => 3;

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                item.IdentifyFlags.Set(Constants.IdentCursed);
            }
        }
    }
}
