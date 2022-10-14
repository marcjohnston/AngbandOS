using AngbandOS.Enumerations;
using AngbandOS.StaticData;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletSearching : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Searching";

        public override int Chance1 => 4;
        public override int Cost => 600;
        public override string FriendlyName => "Searching";
        public override bool HideType => true;
        public override int Level => 30;
        public override int Locale1 => 30;
        public override bool Search => true;
        public override int Weight => 3;

        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                item.IdentifyFlags.Set(Constants.IdentBroken);
                item.IdentifyFlags.Set(Constants.IdentCursed);
                item.TypeSpecificValue = 0 - item.TypeSpecificValue;
            }
        }
    }
}
