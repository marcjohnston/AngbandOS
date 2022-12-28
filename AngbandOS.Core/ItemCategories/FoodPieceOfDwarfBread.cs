using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class FoodPieceOfDwarfBread : FoodItemClass
    {
        public FoodPieceOfDwarfBread(SaveGame saveGame) : base(saveGame) { }

        public override char Character => ',';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Piece of Dwarf Bread";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 16;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "& Piece~ of Dwarf Bread";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Pval => 7500;
        public override int? SubCategory => 41;
        public override int Weight => 3;
        public override bool Eat(SaveGame saveGame)
        {
            saveGame.MsgPrint("You look at the dwarf bread, and don't feel quite so hungry anymore.");
            return true;
        }
    }
}
