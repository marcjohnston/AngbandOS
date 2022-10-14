using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SwordBrokenDagger : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.Black;
        public override string Name => "Sword:Broken Dagger";

        public override int Chance1 => 1;
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Broken Dagger~";
        public override bool ShowMods => true;
        public override int? SubCategory => 1;
        public override int ToD => -4;
        public override int ToH => -2;
        public override int Weight => 5;
    }
}
