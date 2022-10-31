using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ChaosBookTheBookofAzathoth : ChaosBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Red;
        public override string Name => "[The Book of Azathoth]";

        public override int Chance1 => 3;
        public override int Cost => 100000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[The Book of Azathoth]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 100;
        public override int Locale1 => 100;
        public override int? SubCategory => 3;
        public override int Weight => 30;
        public override bool KindIsGood => true;
    }
}
