using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class DragArmorLawDragonScaleMail : DragArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.Grey;
        public override string Name => "DragArmor:Law Dragon Scale Mail";

        public override int Ac => 30;
        public override bool Activate => true;
        public override int Chance1 => 16;
        public override int Cost => 80000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Law Dragon Scale Mail~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 80;
        public override int Locale1 => 80;
        public override bool ResShards => true;
        public override bool ResSound => true;
        public override int SubCategory => 12;
        public override int ToA => 10;
        public override int ToH => -2;
        public override int Weight => 200;
    }
}
