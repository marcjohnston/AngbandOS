using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class HaftedMaceofDisruption : HaftedItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Hafted:Mace of Disruption";

        public override int Chance1 => 8;
        public override int Cost => 4300;
        public override int Dd => 5;
        public override int Ds => 8;
        public override string FriendlyName => "& Mace~ of Disruption";
        public override int Level => 80;
        public override int Locale1 => 80;
        public override bool ShowMods => true;
        public override bool SlayUndead => true;
        public override int SubCategory => 20;
        public override int Weight => 400;
    }
}
