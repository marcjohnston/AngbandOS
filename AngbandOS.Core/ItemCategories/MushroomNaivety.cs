using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomNaivety : MushroomFoodItemClass
    {
        private MushroomNaivety(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Naivety";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Naivety";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 9;
        public override int Weight => 1;
        public override bool Eat(SaveGame saveGame)
        {
            saveGame.Player.TakeHit(Program.Rng.DiceRoll(8, 8), "poisonous food.");
            saveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
            return true;
        }
    }
}
