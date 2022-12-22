using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HaftedLeadFilledMace : HaftedItemClass
    {
        private HaftedLeadFilledMace(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Lead-Filled Mace";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 502;
        public override int Dd => 3;
        public override int Ds => 4;
        public override string FriendlyName => "& Lead-Filled Mace~";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 15;
        public override int Weight => 180;
    }
}
