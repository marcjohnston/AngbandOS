using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingSeeInvisible : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "See Invisible";

        public override int Chance1 => 1;
        public override int Cost => 340;
        public override bool EasyKnow => true;
        public override string FriendlyName => "See Invisible";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override bool SeeInvis => true;
        public override int? SubCategory => 22;
        public override int Weight => 2;
    }
}
