using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingStupidity : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Stupidity";

        public override int Chance1 => 1;
        public override bool Cursed => true;
        public override string FriendlyName => "Stupidity";
        public override bool HideType => true;
        public override bool Int => true;
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Pval => -5;
        public override int? SubCategory => 3;
        public override int Weight => 2;
    }
}
