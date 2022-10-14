using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollAcquirement : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Acquirement";

        public override int Chance1 => 8;
        public override int Cost => 100000;
        public override string FriendlyName => "Acquirement";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => 46;
        public override int Weight => 5;
    }
}
