using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingDamage : RingItemCategory
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Background;
        public override string Name => "Ring:Damage";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override string FriendlyName => "Damage";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 29;
        public override int Weight => 2;
    }
}
