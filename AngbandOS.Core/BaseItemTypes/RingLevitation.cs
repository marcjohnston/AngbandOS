using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingLevitation : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Levitation";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override bool EasyKnow => true;
        public override bool Feather => true;
        public override string FriendlyName => "Levitation";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => 7;
        public override int Weight => 2;
    }
}
