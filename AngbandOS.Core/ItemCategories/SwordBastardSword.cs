using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordBastardSword : SwordItemClass
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Bastard Sword";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 350;
        public override int Dd => 3;
        public override int Ds => 4;
        public override string FriendlyName => "& Bastard Sword~";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 21;
        public override int Weight => 140;
    }
}
