using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionIntelligence : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Intelligence";

        public override int[] Chance => new int[] { 6, 3, 1, 0 };
        public override int Cost => 8000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Intelligence";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 25, 30, 0 };
        public override int? SubCategory => (int)PotionType.IncInt;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Intelligence increases your intelligence
            return saveGame.Player.TryIncreasingAbilityScore(Ability.Intelligence);
        }
    }
}
