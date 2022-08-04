using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class AmuletDOOM : AmuletItemCategory
    {
        public override char Character => '"';
        public override Colour Colour => Colour.Background;
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
        public override int Weight => 3;
        public override bool Wis => true;
    }
}
