using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollLight : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Light";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 15;
        public override string FriendlyName => "Light";
        public override int Locale2 => 3;
        public override int Locale3 => 10;
        public override int? SubCategory => 24;
        public override int Weight => 5;
    }
}
