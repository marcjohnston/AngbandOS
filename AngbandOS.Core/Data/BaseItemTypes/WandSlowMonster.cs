using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class WandSlowMonster : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Slow Monster";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Slow Monster";
        public override int Level => 5;
        public override int Locale1 => 2;
        public override int SubCategory => 9;
        public override int Weight => 10;
    }
}
