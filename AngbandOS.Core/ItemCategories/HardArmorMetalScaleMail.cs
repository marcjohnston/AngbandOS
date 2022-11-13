using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HardArmorMetalScaleMail : HardArmorItemClass
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Metal Scale Mail";

        public override int Ac => 13;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 550;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Metal Scale Mail~";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int ToH => -2;
        public override int Weight => 250;
    }
}
