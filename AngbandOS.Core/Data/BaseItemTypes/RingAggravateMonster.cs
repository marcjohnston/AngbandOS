using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingAggravateMonster : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Aggravate Monster";

        public override bool Aggravate => true;
        public override int Chance1 => 1;
        public override bool Cursed => true;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Aggravate Monster";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 1;
        public override int Weight => 2;
    }
}
