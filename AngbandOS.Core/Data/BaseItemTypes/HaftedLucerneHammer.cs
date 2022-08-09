using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class HaftedLucerneHammer : HaftedItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Hafted:Lucerne Hammer";

        public override int Chance1 => 1;
        public override int Cost => 376;
        public override int Dd => 2;
        public override int Ds => 5;
        public override string FriendlyName => "& Lucerne Hammer~";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override bool ShowMods => true;
        public override int SubCategory => 10;
        public override int Weight => 120;
    }
}
