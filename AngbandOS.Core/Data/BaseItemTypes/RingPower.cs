using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingPower : RingItemCategory
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Ring:Ring*****";

        public override int Cost => 5000000;
        public override string FriendlyName => "& Ring~";
        public override bool InstaArt => true;
        public override int Level => 110;
        public override int SubCategory => 37;
        public override int Weight => 2;
    }
}
