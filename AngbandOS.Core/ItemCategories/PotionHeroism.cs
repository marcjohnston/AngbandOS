using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionHeroism : PotionItemClass
    {
        private PotionHeroism(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Heroism";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 35;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Heroism";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.Heroism;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;
            // Heroism removes fear, cures 10 health, and gives you timed heroism
            if (saveGame.Player.SetTimedFear(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedHeroism(saveGame.Player.TimedHeroism + Program.Rng.DieRoll(25) + 25))
            {
                identified = true;
            }
            if (saveGame.Player.RestoreHealth(10))
            {
                identified = true;
            }
            return identified;
        }
    }
}
