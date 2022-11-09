using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class DragArmorBronzeDragonScaleMail : DragArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Bronze Dragon Scale Mail";

        public override int Ac => 30;
        public override bool Activate => true;
        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 30000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Bronze Dragon Scale Mail~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 55;
        public override int[] Locale => new int[] { 55, 0, 0, 0 };
        public override bool ResConf => true;
        public override int? SubCategory => 14;
        public override int ToA => 10;
        public override int ToH => -2;
        public override int Weight => 200;
    }
}
