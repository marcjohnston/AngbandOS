using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionIntelligence : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Intelligence";

        public override int Chance1 => 6;
        public override int Chance2 => 3;
        public override int Chance3 => 1;
        public override int Cost => 8000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Intelligence";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int Locale2 => 25;
        public override int Locale3 => 30;
        public override int? SubCategory => (int)PotionType.IncInt;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Intelligence increases your intelligence
            return saveGame.Player.TryIncreasingAbilityScore(Ability.Intelligence);
        }
    }
}
