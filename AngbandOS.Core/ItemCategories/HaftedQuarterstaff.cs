using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HaftedQuarterstaff : HaftedItemClass
    {
        public HaftedQuarterstaff(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '\\';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Quarterstaff";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 9;
        public override string FriendlyName => "& Quarterstaff~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 3;
        public override int Weight => 150;
    }
}
