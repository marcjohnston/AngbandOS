using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ChestSmallIron : ChestItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Chest:Small iron chest";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "& Small iron chest~";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int SubCategory => 2;
        public override int Weight => 300;
    }
}
