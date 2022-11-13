using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class NatureBookCallOfTheWild : NatureBookItemClass
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "[Call of the Wild]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Call of the Wild]";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 0;
        public override int Weight => 30;
        public override bool KindIsGood => false;
    }
}
