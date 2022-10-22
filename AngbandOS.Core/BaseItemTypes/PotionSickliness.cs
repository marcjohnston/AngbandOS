using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSickliness : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Sickliness";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Sickliness";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int? SubCategory => (int)PotionType.DecCon;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Sickliness tries to reduce your constitution
            return saveGame.Player.TryDecreasingAbilityScore(Ability.Constitution);
        }
    }
}
