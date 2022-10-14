using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingChaosResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Chaos Resistance";

        public override int Chance1 => 2;
        public override int Cost => 13000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Chaos Resistance";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override bool ResChaos => true;
        public override bool ResConf => true;
        public override int? SubCategory => 46;
        public override int Weight => 2;
    }
}
