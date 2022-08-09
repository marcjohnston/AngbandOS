using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingTulkas : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Ring:Ring*";

        public override int Cost => 150000;
        public override string FriendlyName => "& Ring~";
        public override bool InstaArt => true;
        public override int Level => 90;
        public override int SubCategory => 33;
        public override int Weight => 2;
    }
}
