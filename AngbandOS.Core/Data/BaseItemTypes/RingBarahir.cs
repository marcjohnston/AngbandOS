using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingBarahir : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Ring";

        public override int Cost => 65000;
        public override string FriendlyName => "& Ring~";
        public override bool InstaArt => true;
        public override int Level => 50;
        public override int SubCategory => 32;
        public override int Weight => 2;
    }
}
