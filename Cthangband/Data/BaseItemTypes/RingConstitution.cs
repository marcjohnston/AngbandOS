using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingConstitution : RingItemCategory
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Background;
        public override string Name => "Ring:Constitution";

        public override int Chance1 => 1;
        public override bool Con => true;
        public override int Cost => 500;
        public override string FriendlyName => "Constitution";
        public override bool HideType => true;
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int SubCategory => 27;
        public override int Weight => 2;
    }
}
