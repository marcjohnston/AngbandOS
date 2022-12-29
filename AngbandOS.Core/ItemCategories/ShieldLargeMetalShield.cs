using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ShieldLargeMetalShield : ShieldItemClass
    {
        private ShieldLargeMetalShield(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ')';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Large Metal Shield";

        public override int Ac => 5;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Large Metal Shield~";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 5;
        public override int Weight => 120;
    }
}
