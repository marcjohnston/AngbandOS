using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class HaftedWhip : HaftedItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Hafted:Whip";

        public override int Chance1 => 1;
        public override int Cost => 30;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "& Whip~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override bool ShowMods => true;
        public override int SubCategory => 2;
        public override int Weight => 30;
    }
}
