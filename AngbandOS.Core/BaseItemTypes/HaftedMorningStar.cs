using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HaftedMorningStar : HaftedItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Morning Star";

        public override int Chance1 => 1;
        public override int Cost => 396;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Morning Star~";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override bool ShowMods => true;
        public override int? SubCategory => 12;
        public override int Weight => 150;
    }
}
