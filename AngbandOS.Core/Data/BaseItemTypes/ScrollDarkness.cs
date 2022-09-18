using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollDarkness : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Darkness";

        public override int Chance1 => 1;
        public override string FriendlyName => "Darkness";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int Weight => 5;
    }
}
