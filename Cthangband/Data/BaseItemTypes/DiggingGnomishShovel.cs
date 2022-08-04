using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class DiggingGnomishShovel : DiggingItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Digging:Gnomish Shovel";

        public override int Chance1 => 4;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Gnomish Shovel~";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int Pval => 2;
        public override bool ShowMods => true;
        public override int SubCategory => 2;
        public override bool Tunnel => true;
        public override int Weight => 60;
    }
}
