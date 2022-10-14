using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ChestSmallSteel : ChestItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Small steel chest";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "& Small steel chest~";
        public override int Level => 45;
        public override int Locale1 => 45;
        public override int? SubCategory => 3;
        public override int Weight => 500;
    }
}
