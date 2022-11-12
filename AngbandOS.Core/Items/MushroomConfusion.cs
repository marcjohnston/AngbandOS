using AngbandOS.Enumerations;
using System;
using System.Collections.Generic;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomConfusion : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Confusion";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Confusion";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 3;
        public override int Weight => 1;

        public override bool Eat(SaveGame saveGame)
        {
            if (!saveGame.Player.HasConfusionResistance)
            {
                if (saveGame.Player.SetTimedConfusion(saveGame.Player.TimedConfusion + Program.Rng.RandomLessThan(10) + 10))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
