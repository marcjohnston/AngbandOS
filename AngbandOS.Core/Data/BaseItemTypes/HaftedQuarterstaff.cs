using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HaftedQuarterstaff : HaftedItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Quarterstaff";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 9;
        public override string FriendlyName => "& Quarterstaff~";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override bool ShowMods => true;
        public override int? SubCategory => 3;
        public override int Weight => 150;
    }
}
