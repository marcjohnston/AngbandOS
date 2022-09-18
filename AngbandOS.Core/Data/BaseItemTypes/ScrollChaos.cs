using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollChaos : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Chaos";

        public override int Chance1 => 8;
        public override int Cost => 10000;
        public override string FriendlyName => "Chaos";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 100;
        public override int Locale1 => 100;
        public override int SubCategory => 50;
        public override int Weight => 5;
    }
}
