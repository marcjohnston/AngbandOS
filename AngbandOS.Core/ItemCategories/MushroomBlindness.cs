using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomBlindness : MushroomFoodItemClass
    {
        public override char Character => ',';
        public override string Name => "Blindness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Blindness";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 1;
        public override int Weight => 1;

        public override bool Eat(SaveGame saveGame)
        {
            if (!saveGame.Player.HasBlindnessResistance)
            {
                if (saveGame.Player.SetTimedBlindness(saveGame.Player.TimedBlindness + Program.Rng.RandomLessThan(200) + 200))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
