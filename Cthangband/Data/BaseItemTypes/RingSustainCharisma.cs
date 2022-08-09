using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingSustainCharisma : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Sustain Charisma";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Charisma";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 15;
        public override bool SustCha => true;
        public override int Weight => 2;
    }
}
