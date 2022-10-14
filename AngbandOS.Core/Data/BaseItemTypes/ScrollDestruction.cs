using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollDestruction : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:*Destruction*";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override string FriendlyName => "*Destruction*";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int? SubCategory => 41;
        public override int Weight => 5;
    }
}
