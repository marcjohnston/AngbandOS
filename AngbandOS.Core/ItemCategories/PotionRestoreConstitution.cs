using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionRestoreConstitution : PotionItemClass
    {
        public PotionRestoreConstitution(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '!';
        public override string Name => "Restore Constitution";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Constitution";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.ResCon;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Restore constitution restores your constitution
            return saveGame.Player.TryRestoringAbilityScore(Ability.Constitution);
        }
    }
}
