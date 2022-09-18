using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HaftedLeadFilledMace : HaftedItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Hafted:Lead-Filled Mace";

        public override int Chance1 => 1;
        public override int Cost => 502;
        public override int Dd => 3;
        public override int Ds => 4;
        public override string FriendlyName => "& Lead-Filled Mace~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override bool ShowMods => true;
        public override int SubCategory => 15;
        public override int Weight => 180;
    }
}
