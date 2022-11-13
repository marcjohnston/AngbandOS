using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HelmIronHelm : HelmItemClass
    {
        public override char Character => ']';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Iron Helm";

        public override int Ac => 5;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 75;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Iron Helm~";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 5;
        public override int Weight => 75;
    }
}
