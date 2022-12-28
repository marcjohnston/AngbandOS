using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionInfravision : PotionItemClass
    {
        private PotionInfravision(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Infra-vision";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 20;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Infra-vision";
        public override int Level => 3;
        public override int[] Locale => new int[] { 3, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.Infravision;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Infravision gives you timed infravision
            return saveGame.Player.SetTimedInfravision(saveGame.Player.TimedInfravision + 100 + Program.Rng.DieRoll(100));
        }
    }
}
