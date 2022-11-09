using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingVilya : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Vilya";

        public override int Cost => 300000;
        public override string FriendlyName => "& Ring~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 100;
        public override int? SubCategory => 36;
        public override int Weight => 2;
    }
}
