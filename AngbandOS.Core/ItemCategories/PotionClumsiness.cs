using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionClumsiness : PotionItemClass
    {
        private PotionClumsiness(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Clumsiness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Clumsiness";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.DecDex;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Clumsiness tries to reduce your dexterity
            return saveGame.Player.TryDecreasingAbilityScore(Ability.Dexterity);
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return true;
        }
    }
}
