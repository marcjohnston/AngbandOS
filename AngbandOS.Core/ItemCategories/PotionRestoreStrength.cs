using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionRestoreStrength : PotionItemClass
    {
        private PotionRestoreStrength(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Restore Strength";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Strength";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.ResStr;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Restore strength restores your strength
            return saveGame.Player.TryRestoringAbilityScore(Ability.Strength);
        }
    }
}
