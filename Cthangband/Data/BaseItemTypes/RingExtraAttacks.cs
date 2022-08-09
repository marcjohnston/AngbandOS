using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingExtraAttacks : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Extra Attacks";

        public override bool Blows => true;
        public override int Chance1 => 2;
        public override int Cost => 100000;
        public override string FriendlyName => "Extra Attacks";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int SubCategory => 49;
        public override int Weight => 2;
    }
}
