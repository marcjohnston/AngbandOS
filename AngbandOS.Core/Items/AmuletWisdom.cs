using AngbandOS.Core;
using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletWisdom : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Wisdom";
        public override bool Wis => true;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Wisdom";
        public override bool HideType => true;
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int Weight => 3;

        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = 1 + GetBonusValue(5, level);
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                item.IdentBroken = true;
                item.IdentCursed = true;
                item.TypeSpecificValue = 0 - item.TypeSpecificValue;
            }
        }
    }
}
