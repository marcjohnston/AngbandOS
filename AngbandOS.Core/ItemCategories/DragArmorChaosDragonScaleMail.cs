using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DragArmorChaosDragonScaleMail : DragArmorItemClass
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos Dragon Scale Mail";

        public override int Ac => 30;
        public override bool Activate => true;
        public override int[] Chance => new int[] { 16, 0, 0, 0 };
        public override int Cost => 70000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Chaos Dragon Scale Mail~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 75;
        public override int[] Locale => new int[] { 75, 0, 0, 0 };
        public override bool ResChaos => true;
        public override bool ResDisen => true;
        public override int? SubCategory => 18;
        public override int ToA => 10;
        public override int ToH => -2;
        public override int Weight => 200;
    }
}
