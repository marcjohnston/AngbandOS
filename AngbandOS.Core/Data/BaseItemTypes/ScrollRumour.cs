using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollRumour : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Rumour";

        public override int Chance1 => 1;
        public override int Cost => 10;
        public override string FriendlyName => "Rumour";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int? SubCategory => 51;
        public override int Weight => 5;
    }
}
