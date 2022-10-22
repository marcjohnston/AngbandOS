using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionRestoreIntelligence : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Restore Intelligence";

        public override int Chance1 => 1;
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Intelligence";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int? SubCategory => (int)PotionType.ResInt;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Restore intelligence restores your intelligence
            return saveGame.Player.TryRestoringAbilityScore(Ability.Intelligence);
        }
    }
}
