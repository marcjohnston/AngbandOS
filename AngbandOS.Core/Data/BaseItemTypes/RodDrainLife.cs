using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodDrainLife : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Drain Life";

        public override int Chance1 => 4;
        public override int Cost => 3600;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Drain Life";
        public override int Level => 75;
        public override int Locale1 => 75;
        public override int? SubCategory => 18;
        public override int Weight => 15;
    }
}
