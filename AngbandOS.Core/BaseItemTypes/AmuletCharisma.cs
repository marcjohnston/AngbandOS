using AngbandOS.Enumerations;
using AngbandOS.StaticData;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletCharisma : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Charisma";

        public override bool Cha => true;
        public override int Chance1 => 1;
        public override int Cost => 500;
        public override string FriendlyName => "Charisma";
        public override bool HideType => true;
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int Weight => 3;

        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = 1 + GetBonusValue(5, level);
            if (power < 0 || (power == 0 && Program.Rng.RandomLessThan(100) < 50))
            {
                item.IdentifyFlags.Set(Constants.IdentBroken);
                item.IdentifyFlags.Set(Constants.IdentCursed);
                item.TypeSpecificValue = 0 - item.TypeSpecificValue;
            }
        }
    }
}
