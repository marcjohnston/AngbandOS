using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionAppleJuice : PotionItemClass
    {
        private PotionAppleJuice(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Apple Juice";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Apple Juice";
        public override int Pval => 250;
        public override int? SubCategory => (int)PotionType.AppleJuice;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Apple juice has no effect
            saveGame.MsgPrint("You feel less thirsty.");
            return true;
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return true;
        }
    }
}
