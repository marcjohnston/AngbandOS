using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DiggingPick : DiggingItemClass
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Pick";

        public override int[] Chance => new int[] { 16, 0, 0, 0 };
        public override int Cost => 50;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Pick~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int Pval => 1;
        public override bool ShowMods => true;
        public override bool Tunnel => true;
        public override int Weight => 150;
    }
}