using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HaftedLucerneHammer : HaftedItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Lucerne Hammer";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 376;
        public override int Dd => 2;
        public override int Ds => 5;
        public override string FriendlyName => "& Lucerne Hammer~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 10;
        public override int Weight => 120;
    }
}