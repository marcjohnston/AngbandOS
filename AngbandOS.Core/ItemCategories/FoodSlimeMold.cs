using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class FoodSlimeMold : FoodItemClass
    {
        public FoodSlimeMold(SaveGame saveGame) : base(saveGame) { }

        public override char Character => ',';
        public override Colour Colour => Colour.Green;
        public override string Name => "Slime Mold";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2;
        public override string FriendlyName => "& Slime Mold~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int Pval => 3000;
        public override int? SubCategory => 36;
        public override int Weight => 5;
        public override bool Eat(SaveGame saveGame)
        {
            // Eating a slime mold is the same as quaffing a potion of slime mold.
            PotionItemClass slimeMold = new PotionSlimeMoldJuice(saveGame);
            slimeMold.Quaff(saveGame);
            return true;
        }
    }
}
