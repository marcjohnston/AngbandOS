using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HardArmorAdamantitePlateMail : HardArmorItemCategory
    {
        public override char Character => '[';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Adamantite Plate Mail";

        public override int Ac => 40;
        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 20000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Adamantite Plate Mail~";
        public override bool IgnoreAcid => true;
        public override int Level => 75;
        public override int[] Locale => new int[] { 75, 0, 0, 0 };
        public override int? SubCategory => 30;
        public override int ToH => -4;
        public override int Weight => 420;
    }
}
