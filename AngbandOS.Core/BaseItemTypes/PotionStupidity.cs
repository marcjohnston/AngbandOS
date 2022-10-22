using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionStupidity : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Stupidity";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Stupidity";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => (int)PotionType.DecInt;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Stupidity tries to reduce your intelligence
            return saveGame.Player.TryDecreasingAbilityScore(Ability.Intelligence);
        }
    }
}
