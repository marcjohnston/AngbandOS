using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SwordDagger : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sword:Dagger";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Chance4 => 1;
        public override int Cost => 10;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "& Dagger~";
        public override int Locale2 => 5;
        public override int Locale3 => 10;
        public override int Locale4 => 20;
        public override bool ShowMods => true;
        public override int SubCategory => 4;
        public override int Weight => 12;
    }
}
