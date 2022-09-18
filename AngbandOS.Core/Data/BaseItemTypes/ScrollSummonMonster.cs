using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollSummonMonster : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Summon Monster";

        public override int Chance1 => 1;
        public override string FriendlyName => "Summon Monster";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int SubCategory => 4;
        public override int Weight => 5;
    }
}
