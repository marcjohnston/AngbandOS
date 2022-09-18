using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollDetectInvisible : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Detect Invisible";

        public override int Chance1 => 1;
        public override int Cost => 15;
        public override string FriendlyName => "Detect Invisible";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int SubCategory => 30;
        public override int Weight => 5;
    }
}
