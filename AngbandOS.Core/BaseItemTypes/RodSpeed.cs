using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodSpeed : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Speed";

        public override int Chance1 => 16;
        public override int Cost => 50000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Speed";
        public override int Level => 95;
        public override int Locale1 => 95;
        public override int? SubCategory => 11;
        public override int Weight => 15;
    }
}
