using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class DragArmorBalanceDragonScaleMail : DragArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Silver;
        public override string Name => "DragArmor:Balance Dragon Scale Mail";

        public override int Ac => 30;
        public override bool Activate => true;
        public override int Chance1 => 16;
        public override int Cost => 100000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Balance Dragon Scale Mail~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 90;
        public override int Locale1 => 90;
        public override bool ResChaos => true;
        public override bool ResDisen => true;
        public override bool ResShards => true;
        public override bool ResSound => true;
        public override int SubCategory => 20;
        public override int ToA => 10;
        public override int ToH => -2;
        public override int Weight => 200;
    }
}
