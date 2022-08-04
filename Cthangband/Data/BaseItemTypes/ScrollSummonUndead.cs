using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollSummonUndead : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Summon Undead";

        public override int Chance1 => 1;
        public override string FriendlyName => "Summon Undead";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int SubCategory => 5;
        public override int Weight => 5;
    }
}
