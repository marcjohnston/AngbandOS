using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionResistHeat : PotionItemClass
    {
        private PotionResistHeat(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Resist Heat";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 30;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Resist Heat";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.ResistHeat;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Resist heat gives you timed fire resistance
            return saveGame.Player.SetTimedFireResistance(saveGame.Player.TimedFireResistance + Program.Rng.DieRoll(10) + 10);
        }
    }
}
