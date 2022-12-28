using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionSickliness : PotionItemClass
    {
        public PotionSickliness(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '!';
        public override string Name => "Sickliness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Sickliness";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.DecCon;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Sickliness tries to reduce your constitution
            return saveGame.Player.TryDecreasingAbilityScore(Ability.Constitution);
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return true;
        }
    }
}
