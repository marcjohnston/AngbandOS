using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class DiggingPick : DiggingItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Digging:Pick";

        public override int Chance1 => 16;
        public override int Cost => 50;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Pick~";
        public override int Level => 5;
        public override int Locale1 => 10;
        public override int Pval => 1;
        public override bool ShowMods => true;
        public override int SubCategory => 4;
        public override bool Tunnel => true;
        public override int Weight => 150;
    }
}
