using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ShotIronShot : ShotItemClass
    {
        public override char Character => '{';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Iron Shot";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Iron Shot~";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 1;
        public override int Weight => 5;
    }
}
