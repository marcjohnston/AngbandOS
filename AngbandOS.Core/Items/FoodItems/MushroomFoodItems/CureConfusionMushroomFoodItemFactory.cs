namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class CureConfusionMushroomFoodItemFactory : MushroomFoodItemFactory
    {
        private CureConfusionMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Cure Confusion";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 50;
        public override string FriendlyName => "Cure Confusion";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 15;
        public override int Weight => 1;
        public override bool Eat(SaveGame saveGame)
        {
            if (saveGame.Player.TimedConfusion.ResetTimer())
            {
                return true;
            }
            return false;
        }
        public override Item CreateItem() => new CureConfusionMushroomFoodItem(SaveGame);
    }
}