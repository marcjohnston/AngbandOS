using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class MushroomPoison : MushroomFoodItemClass
    {
        private MushroomPoison(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ',';
        public override string Name => "Poison";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Dd => 4;
        public override int Ds => 4;
        public override string FriendlyName => "Poison";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 5, 0, 0 };
        public override int Pval => 500;
        public override int? SubCategory => 0;
        public override int Weight => 1;

        public override bool Eat(SaveGame saveGame)
        {
            if (!(saveGame.Player.HasPoisonResistance || saveGame.Player.TimedPoisonResistance != 0))
            {
                // Hagarg Ryonis may protect us from poison
                if (Program.Rng.DieRoll(10) <= saveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                {
                    saveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
                }
                else if (saveGame.Player.SetTimedPoison(saveGame.Player.TimedPoison + Program.Rng.RandomLessThan(10) + 10))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
