using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollDispelUndead : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Dispel Undead";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override string FriendlyName => "Dispel Undead";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int SubCategory => 42;
        public override int Weight => 5;
    }
}
