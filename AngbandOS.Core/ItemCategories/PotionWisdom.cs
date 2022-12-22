using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionWisdom : PotionItemClass
    {
        private PotionWisdom(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Wisdom";

        public override int[] Chance => new int[] { 6, 3, 1, 0 };
        public override int Cost => 8000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Wisdom";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 25, 30, 0 };
        public override int? SubCategory => (int)PotionType.IncWis;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Wisdom increases your wisdom
            return saveGame.Player.TryIncreasingAbilityScore(Ability.Wisdom);
        }
    }
}
