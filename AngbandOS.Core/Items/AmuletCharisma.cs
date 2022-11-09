using AngbandOS.Core;
using AngbandOS.Enumerations;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletCharisma : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Charisma";

        public override bool Cha => true;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Charisma";
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
