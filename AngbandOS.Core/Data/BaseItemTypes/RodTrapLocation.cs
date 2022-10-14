using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodTrapLocation : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Trap Location";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Trap Location";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => 0;
        public override int Weight => 15;
    }
}
