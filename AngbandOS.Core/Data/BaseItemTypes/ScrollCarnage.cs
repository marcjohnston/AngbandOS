using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollCarnage : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Carnage";

        public override int Chance1 => 4;
        public override int Chance2 => 4;
        public override int Cost => 750;
        public override string FriendlyName => "Carnage";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int Locale2 => 80;
        public override int SubCategory => 44;
        public override int Weight => 5;
    }
}
