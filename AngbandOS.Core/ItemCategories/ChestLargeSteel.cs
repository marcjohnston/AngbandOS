using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ChestLargeSteel : ChestItemClass
    {
        public ChestLargeSteel(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Large steel chest";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 250;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Large steel chest~";
        public override int Level => 55;
        public override int[] Locale => new int[] { 55, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int Weight => 1000;
        public override bool IsSmall => false;
        public override int NumberOfItemsContained => 6;
    }
}
