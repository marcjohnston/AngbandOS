using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomCurePoison : MushroomFoodItemClass
    {
        public MushroomCurePoison(SaveGame saveGame) : base(saveGame) { }

        public override char Character => ',';
        public override string Name => "Cure Poison";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 60;
        public override string FriendlyName => "Cure Poison";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 12;
        public override int Weight => 1;
        public override bool Eat(SaveGame saveGame)
        {
            if (saveGame.Player.SetTimedPoison(0))
            {
                return true;
            }
            return false;
        }
    }
}
