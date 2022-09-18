using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollIce : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Ice";

        public override int Chance1 => 6;
        public override int Cost => 5000;
        public override string FriendlyName => "Ice";
        public override bool IgnoreCold => true;
        public override int Level => 75;
        public override int Locale1 => 75;
        public override int SubCategory => 49;
        public override int Weight => 5;
    }
}
