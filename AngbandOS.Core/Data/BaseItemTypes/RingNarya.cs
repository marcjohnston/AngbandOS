using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingNarya : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Ring**";

        public override int Cost => 100000;
        public override string FriendlyName => "& Ring~";
        public override bool InstaArt => true;
        public override int Level => 80;
        public override int SubCategory => 34;
        public override int Weight => 2;
    }
}
