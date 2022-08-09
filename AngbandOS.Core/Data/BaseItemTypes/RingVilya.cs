using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingVilya : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Ring****";

        public override int Cost => 300000;
        public override string FriendlyName => "& Ring~";
        public override bool InstaArt => true;
        public override int Level => 100;
        public override int SubCategory => 36;
        public override int Weight => 2;
    }
}
