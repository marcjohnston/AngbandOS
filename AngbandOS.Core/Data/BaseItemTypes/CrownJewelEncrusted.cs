using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class CrownJewelEncrusted : CrownItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Crown:Jewel Encrusted Crown";

        public override int Chance1 => 1;
        public override int Cost => 2000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Jewel Encrusted Crown~";
        public override bool IgnoreAcid => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int? SubCategory => 12;
        public override int Weight => 40;
    }
}
