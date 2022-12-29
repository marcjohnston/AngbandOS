using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordTwoHandedSword : SwordItemClass
    {
        private SwordTwoHandedSword(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Two-Handed Sword";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 775;
        public override int Dd => 3;
        public override int Ds => 6;
        public override string FriendlyName => "& Two-Handed Sword~";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 40, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 25;
        public override int Weight => 200;
    }
}
