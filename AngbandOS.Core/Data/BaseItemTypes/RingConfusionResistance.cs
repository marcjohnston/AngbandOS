using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingConfusionResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Confusion Resistance";

        public override int Chance1 => 2;
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Confusion Resistance";
        public override int Level => 22;
        public override int Locale1 => 22;
        public override bool ResConf => true;
        public override int SubCategory => 43;
        public override int Weight => 2;
    }
}
