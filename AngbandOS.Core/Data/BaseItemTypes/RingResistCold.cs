using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingResistCold : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Resist Cold";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Resist Cold";
        public override bool IgnoreCold => true;
        public override int Level => 10;
        public override int Locale1 => 10;
        public override bool ResCold => true;
        public override int? SubCategory => 9;
        public override int Weight => 2;
    }
}
