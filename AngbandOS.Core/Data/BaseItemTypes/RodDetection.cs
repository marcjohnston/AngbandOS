using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodDetection : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Detection";

        public override int Chance1 => 8;
        public override int Cost => 5000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Detection";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int? SubCategory => 6;
        public override int Weight => 15;
    }
}
