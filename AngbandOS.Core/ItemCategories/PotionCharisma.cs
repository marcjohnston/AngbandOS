using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionCharisma : PotionItemClass
    {
        private PotionCharisma(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Charisma";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Charisma";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 25, 0, 0 };
        public override int? SubCategory => (int)PotionType.IncCha;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Charisma increases your charisma
            return saveGame.Player.TryIncreasingAbilityScore(Ability.Charisma);
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return true;
        }
    }
}
