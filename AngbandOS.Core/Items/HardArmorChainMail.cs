using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HardArmorChainMail : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Chain Mail";

        public override int Ac => 14;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 750;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Chain Mail~";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => 4;
        public override int ToH => -2;
        public override int Weight => 220;
    }
}