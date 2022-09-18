using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollHolyChant : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Holy Chant";

        public override int Chance1 => 1;
        public override int Cost => 40;
        public override string FriendlyName => "Holy Chant";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int SubCategory => 34;
        public override int Weight => 5;
    }
}
