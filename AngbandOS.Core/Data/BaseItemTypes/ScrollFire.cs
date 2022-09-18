using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollFire : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Fire";

        public override int Chance1 => 4;
        public override int Cost => 1000;
        public override string FriendlyName => "Fire";
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int SubCategory => 48;
        public override int Weight => 5;
    }
}
