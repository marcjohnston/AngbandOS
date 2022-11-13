using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ShieldDragonShield : ShieldItemClass
    {
        public override char Character => '[';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Dragon Shield";

        public override int Ac => 8;
        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 10000;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Dragon Shield~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 70;
        public override int[] Locale => new int[] { 80, 0, 0, 0 };
        public override int? SubCategory => 6;
        public override int ToA => 10;
        public override int Weight => 100;
    }
}
