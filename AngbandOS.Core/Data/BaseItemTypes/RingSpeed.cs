using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingSpeed : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Speed";

        public override int Chance1 => 1;
        public override int Cost => 100000;
        public override string FriendlyName => "Speed";
        public override bool HideType => true;
        public override int Level => 80;
        public override int Locale1 => 80;
        public override bool Speed => true;
        public override int SubCategory => 31;
        public override int Weight => 2;
    }
}
