using AngbandOS.Enumerations;
using System;
using System.Collections.Generic;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class MushroomHallucination : MushroomFoodItemCategory
    {
        public override char Character => ',';
        public override string Name => "Hallucination";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Hallucination";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 4;
        public override int Weight => 1;

        public override bool Eat(SaveGame saveGame)
        {
            if (!saveGame.Player.HasChaosResistance)
            {
                if (saveGame.Player.SetTimedHallucinations(saveGame.Player.TimedHallucinations + Program.Rng.RandomLessThan(250) + 250))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
