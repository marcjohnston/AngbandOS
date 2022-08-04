using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class DiggingOrcishPick : DiggingItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Green;
        public override string Name => "Digging:Orcish Pick";

        public override int Chance1 => 4;
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Orcish Pick~";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int Pval => 2;
        public override bool ShowMods => true;
        public override int SubCategory => 5;
        public override bool Tunnel => true;
        public override int Weight => 150;
    }
}
