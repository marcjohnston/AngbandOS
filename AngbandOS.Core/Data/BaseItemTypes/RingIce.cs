using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingIce : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Ice";

        public override bool Activate => true;
        public override int Chance1 => 1;
        public override int Cost => 3000;
        public override string FriendlyName => "Ice";
        public override bool IgnoreCold => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override bool ResCold => true;
        public override int? SubCategory => 19;
        public override int ToA => 15;
        public override int Weight => 2;
    }
}
