using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomStupidity : MushroomFoodItemClass
    {
        public override char Character => ',';
        public override string Name => "Stupidity";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Stupidity";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 8;
        public override int Weight => 1;
        public override bool Eat(SaveGame saveGame)
        {
            saveGame.Player.TakeHit(Program.Rng.DiceRoll(8, 8), "poisonous food.");
            saveGame.Player.TryDecreasingAbilityScore(Ability.Intelligence);
            return true;
        }
    }
}
