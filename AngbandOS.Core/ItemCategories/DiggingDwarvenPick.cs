using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DiggingDwarvenPick : DiggingItemClass
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Dwarven Pick";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 600;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "& Dwarven Pick~";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int Pval => 3;
        public override bool ShowMods => true;
        public override bool Tunnel => true;
        public override int Weight => 200;
    }
}