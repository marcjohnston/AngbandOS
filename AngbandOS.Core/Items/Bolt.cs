using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class Bolt : BoltItemCategory
    {
        public override char Character => '{';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Bolt";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 2;
        public override int Dd => 1;
        public override int Ds => 5;
        public override string FriendlyName => "& Bolt~";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 25, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 1;
        public override int Weight => 3;
    }
}
