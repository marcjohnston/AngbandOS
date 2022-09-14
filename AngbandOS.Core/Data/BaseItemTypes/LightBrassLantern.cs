using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class LightBrassLantern : LightItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Light:Brass Lantern";

        public override int Chance1 => 1;
        public override int Cost => 35;
        public override int Dd => 1;
        public override int Ds => 1;
        public override bool EasyKnow => true;
        public override string FriendlyName => "& Brass Lantern~";
        public override bool IgnoreFire => true;
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int Pval => 7500;
        public override int SubCategory => 1;
        public override int Weight => 50;
    }
}
