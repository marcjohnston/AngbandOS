using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomSickness : MushroomFoodItemClass
    {
        private MushroomSickness(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Sickness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 4;
        public override int Ds => 4;
        public override string FriendlyName => "Sickness";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 7;
        public override int Weight => 1;

        public override bool Eat(SaveGame saveGame)
        {
            saveGame.Player.TakeHit(Program.Rng.DiceRoll(6, 6), "poisonous food.");
            saveGame.Player.TryDecreasingAbilityScore(Ability.Constitution);
            return true;
        }
    }
}
