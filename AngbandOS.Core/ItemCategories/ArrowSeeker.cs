using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ArrowSeeker : ArrowItemClass
    {
        public override char Character => '{';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Seeker Arrow";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 20;
        public override int Dd => 4;
        public override int Ds => 4;
        public override string FriendlyName => "& Seeker Arrow~";
        public override int Level => 55;
        public override int[] Locale => new int[] { 55, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 2;
        public override int Weight => 2;
    }
}