using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordBroadSword : SwordItemClass
    {
        private SwordBroadSword(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Broad Sword";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 255;
        public override int Dd => 2;
        public override int Ds => 5;
        public override string FriendlyName => "& Broad Sword~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 15, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 16;
        public override int Weight => 150;
    }
}
