using AngbandOS.Enumerations;
using AngbandOS.StaticData;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class AmuletDOOM : AmuletItemCategory
    {
        public override char Character => '"';
        public override string Name => "Amulet:DOOM";

        public override bool Cha => true;
        public override int Chance1 => 1;
        public override bool Con => true;
        public override bool Cursed => true;
        public override bool Dex => true;
        public override string FriendlyName => "DOOM";
        public override bool HideType => true;
        public override bool Int => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Pval => -5;
        public override bool Str => true;
        public override int SubCategory => AmuletType.Doom;
        public override int Weight => 3;
        public override bool Wis => true;

        public override void ApplyMagic(Item item, int level, int power)
        {
            item.IdentifyFlags.Set(Constants.IdentBroken);
            item.IdentifyFlags.Set(Constants.IdentCursed);
            item.TypeSpecificValue = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
            item.BonusArmourClass = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
        }
    }
}
