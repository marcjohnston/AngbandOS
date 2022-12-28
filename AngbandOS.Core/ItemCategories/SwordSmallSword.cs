using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordSmallSword : SwordItemClass
    {
        public SwordSmallSword(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Small Sword";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 48;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "& Small Sword~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 8;
        public override int Weight => 75;
    }
}
