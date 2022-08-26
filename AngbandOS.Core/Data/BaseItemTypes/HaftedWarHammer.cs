using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class HaftedWarHammer : HaftedItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Hafted:War Hammer";

        public override int Chance1 => 1;
        public override int Cost => 225;
        public override int Dd => 3;
        public override int Ds => 3;
        public override string FriendlyName => "& War Hammer~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override bool ShowMods => true;
        public override int SubCategory => 8;
        public override int Weight => 120;
    }
}
