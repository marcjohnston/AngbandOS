using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingLightandDarknessResistance : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Light and Darkness Resistance";

        public override int Chance1 => 2;
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Light and Darkness Resistance";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override bool ResDark => true;
        public override bool ResLight => true;
        public override int? SubCategory => 39;
        public override int Weight => 2;
    }
}
