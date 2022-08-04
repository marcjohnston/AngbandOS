using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SwordCutlass : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sword:Cutlass";

        public override int Chance1 => 1;
        public override int Cost => 85;
        public override int Dd => 1;
        public override int Ds => 7;
        public override string FriendlyName => "& Cutlass~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override bool ShowMods => true;
        public override int SubCategory => 12;
        public override int Weight => 110;
    }
}
