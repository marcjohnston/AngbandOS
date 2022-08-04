using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RingWoe : RingItemCategory
    {
        public override char Character => '=';
        public override Colour Colour => Colour.Background;
        public override string Name => "Ring:Woe";

        public override bool Cha => true;
        public override int Chance1 => 1;
        public override bool Cursed => true;
        public override string FriendlyName => "Woe";
        public override bool HideType => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Pval => -5;
        public override bool Teleport => true;
        public override int Weight => 2;
        public override bool Wis => true;
    }
}
