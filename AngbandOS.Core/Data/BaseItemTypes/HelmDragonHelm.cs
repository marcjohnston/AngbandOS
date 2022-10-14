using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HelmDragonHelm : HelmItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Helm:Dragon Helm";

        public override int Ac => 8;
        public override int Chance1 => 4;
        public override int Cost => 10000;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Dragon Helm~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 45;
        public override int Locale1 => 80;
        public override int? SubCategory => 7;
        public override int ToA => 10;
        public override int Weight => 50;
    }
}
