using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodHavoc : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Havoc";

        public override int Chance1 => 16;
        public override int Cost => 150000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Havoc";
        public override int Level => 95;
        public override int Locale1 => 100;
        public override int SubCategory => 28;
        public override int Weight => 15;
    }
}
