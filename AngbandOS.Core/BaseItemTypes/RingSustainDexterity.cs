using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingSustainDexterity : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Sustain Dexterity";

        public override int Chance1 => 1;
        public override int Cost => 750;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Dexterity";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int? SubCategory => 14;
        public override bool SustDex => true;
        public override int Weight => 2;
    }
}
