using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingFlames : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Flames";

        public override bool Activate => true;
        public override int Chance1 => 1;
        public override int Cost => 3000;
        public override string FriendlyName => "Flames";
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override bool ResFire => true;
        public override int SubCategory => 18;
        public override int ToA => 15;
        public override int Weight => 2;
    }
}
