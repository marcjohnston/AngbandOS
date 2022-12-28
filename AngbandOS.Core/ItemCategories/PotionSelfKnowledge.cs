using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionSelfKnowledge : PotionItemClass
    {
        private PotionSelfKnowledge(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Self Knowledge";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Self Knowledge";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.SelfKnowledge;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Self knowledge gives you information about yourself
            saveGame.MsgPrint("You begin to know yourself a little better...");
            saveGame.MsgPrint(null);
            saveGame.SelfKnowledge();
            return true;
        }
    }
}
