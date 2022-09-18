using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingWeakness : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Weakness";

        public override int Chance1 => 1;
        public override bool Cursed => true;
        public override string FriendlyName => "Weakness";
        public override bool HideType => true;
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Pval => -5;
        public override bool Str => true;
        public override int SubCategory => 2;
        public override int Weight => 2;
    }
}
