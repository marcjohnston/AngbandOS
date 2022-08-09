using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingSustainConstitution : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Sustain Constitution";

        public override int Chance1 => 1;
        public override int Cost => 750;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Sustain Constitution";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 13;
        public override bool SustCon => true;
        public override int Weight => 2;
    }
}
