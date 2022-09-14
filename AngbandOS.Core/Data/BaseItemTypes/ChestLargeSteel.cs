using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ChestLargeSteel : ChestItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Chest:Large steel chest";

        public override int Chance1 => 1;
        public override int Cost => 250;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Large steel chest~";
        public override int Level => 55;
        public override int Locale1 => 55;
        public override int SubCategory => 7;
        public override int Weight => 1000;
    }
}
