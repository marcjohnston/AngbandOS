using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionUgliness : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Ugliness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Ugliness";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.DecCha;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Ugliness tries to reduce your charisma
            return saveGame.Player.TryDecreasingAbilityScore(Ability.Charisma);
        }

    }
}