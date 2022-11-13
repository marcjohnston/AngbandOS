using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GlovesSetOfCesti : GlovesItemClass
    {
        public override char Character => ']';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Set of Cesti";

        public override int Ac => 5;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Set~ of Cesti";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int Weight => 40;
    }
}
