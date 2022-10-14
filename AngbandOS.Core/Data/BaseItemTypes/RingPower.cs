using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingPower : RingItemCategory
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Power";

        public override int Cost => 5000000;
        public override string FriendlyName => "& Ring~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 110;
        public override int? SubCategory => 37;
        public override int Weight => 2;
    }
}
