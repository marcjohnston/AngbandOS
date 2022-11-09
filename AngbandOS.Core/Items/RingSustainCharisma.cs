using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingSustainCharisma : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Sustain Charisma";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Charisma";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 15;
        public override bool SustCha => true;
        public override int Weight => 2;
    }
}
