using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionAugmentation : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Augmentation";

        public override int Chance1 => 16;
        public override int Cost => 60000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Augmentation";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int? SubCategory => (int)PotionType.Augmentation;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;

            // Augmentation increases all ability scores
            if (saveGame.Player.TryIncreasingAbilityScore(Ability.Strength))
            {
                identified = true;
            }
            if (saveGame.Player.TryIncreasingAbilityScore(Ability.Intelligence))
            {
                identified = true;
            }
            if (saveGame.Player.TryIncreasingAbilityScore(Ability.Wisdom))
            {
                identified = true;
            }
            if (saveGame.Player.TryIncreasingAbilityScore(Ability.Dexterity))
            {
                identified = true;
            }
            if (saveGame.Player.TryIncreasingAbilityScore(Ability.Constitution))
            {
                identified = true;
            }
            if (saveGame.Player.TryIncreasingAbilityScore(Ability.Charisma))
            {
                identified = true;
            }

            return identified;
        }
    }
}
