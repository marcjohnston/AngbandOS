using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class DiggingDwarvenPick : DiggingItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Digging:Dwarven Pick";

        public override int Chance1 => 1;
        public override int Cost => 600;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "& Dwarven Pick~";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Pval => 3;
        public override bool ShowMods => true;
        public override int SubCategory => 6;
        public override bool Tunnel => true;
        public override int Weight => 200;
    }
}
