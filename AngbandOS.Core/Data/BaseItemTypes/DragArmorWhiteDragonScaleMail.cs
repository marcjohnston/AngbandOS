using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class DragArmorWhiteDragonScaleMail : DragArmorItemCategory
    {
        public override char Character => '[';
        public override string Name => "White Dragon Scale Mail";

        public override int Ac => 30;
        public override bool Activate => true;
        public override int Chance1 => 8;
        public override int Cost => 40000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "White Dragon Scale Mail~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override bool ResCold => true;
        public override int? SubCategory => 3;
        public override int ToA => 10;
        public override int ToH => -2;
        public override int Weight => 200;
    }
}
