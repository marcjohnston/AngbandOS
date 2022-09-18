using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FlaskOfOil : FlaskItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Flask:Flask of oil";

        public override int Chance1 => 1;
        public override int Cost => 3;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Flask~ of oil";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int Pval => 7500;
        public override int Weight => 10;
    }
}
