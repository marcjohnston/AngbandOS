using AngbandOS.Enumerations;
using System;
using System.Collections.Generic;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomParalysis : MushroomFoodItemClass
    {
        public override char Character => ',';
        public override string Name => "Paralysis";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Paralysis";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 5;
        public override int Weight => 1;

        public override bool Eat(SaveGame saveGame)
        {
            if (!saveGame.Player.HasFreeAction)
            {
                if (saveGame.Player.SetTimedParalysis(saveGame.Player.TimedParalysis + Program.Rng.RandomLessThan(10) + 10))
                {
                    return true;
                }
            }
            return false;
        }
    }
}