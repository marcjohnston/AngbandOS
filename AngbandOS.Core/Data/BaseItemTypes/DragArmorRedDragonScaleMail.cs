using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class DragArmorRedDragonScaleMail : DragArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Red;
        public override string Name => "DragArmor:Red Dragon Scale Mail";

        public override int Ac => 30;
        public override bool Activate => true;
        public override int Chance1 => 8;
        public override int Cost => 100000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Red Dragon Scale Mail~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 80;
        public override int Locale1 => 80;
        public override bool ResFire => true;
        public override int SubCategory => 4;
        public override int ToA => 10;
        public override int ToH => -2;
        public override int Weight => 200;
    }
}
