using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingSearching : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Searching";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override string FriendlyName => "Searching";
        public override bool HideType => true;
        public override int Level => 5;
        public override int Locale1 => 5;
        public override bool Search => true;
        public override int SubCategory => 23;
        public override int Weight => 2;
    }
}
