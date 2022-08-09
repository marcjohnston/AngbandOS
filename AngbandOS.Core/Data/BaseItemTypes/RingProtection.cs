using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingProtection : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Protection";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override string FriendlyName => "Protection";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int SubCategory => 16;
        public override int Weight => 2;
    }
}
