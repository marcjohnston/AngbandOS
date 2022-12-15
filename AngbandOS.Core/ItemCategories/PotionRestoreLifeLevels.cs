using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionRestoreLifeLevels : PotionItemClass
    {
        public override char Character => '!';
        public override string Name => "Restore Life Levels";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Life Levels";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.RestoreExp;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Restore life levels restores any lost experience
            return saveGame.Player.RestoreLevel();
        }
    }
}
