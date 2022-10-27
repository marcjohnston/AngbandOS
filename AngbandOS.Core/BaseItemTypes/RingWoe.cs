using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RingWoe : RingItemCategory
    {
        public override char Character => '=';
        public override string Name => "Woe";

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
        public override int? SubCategory => 0;
        public override bool Wis => true;
    }
}
