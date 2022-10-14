using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodSlowMonster : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Slow Monster";

        public override int Chance1 => 1;
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slow Monster";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int? SubCategory => 17;
        public override int Weight => 15;
    }
}
