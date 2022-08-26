using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class LightOrb : LightItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "Light:Orb";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Orb~";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int SubCategory => 7;
        public override int Weight => 50;
    }
}
