using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodDisarming : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Disarming";

        public override int Chance1 => 1;
        public override int Cost => 2100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Disarming";
        public override int Level => 35;
        public override int Locale1 => 35;
        public override int SubCategory => 14;
        public override int Weight => 15;
    }
}
