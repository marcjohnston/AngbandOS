using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollMonsterConfusion : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Monster Confusion";

        public override int Chance1 => 1;
        public override int Cost => 30;
        public override string FriendlyName => "Monster Confusion";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 36;
        public override int Weight => 5;
    }
}
