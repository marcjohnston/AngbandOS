using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionLoseMemories : PotionItemClass
    {
        public override char Character => '!';
        public override string Name => "Lose Memories";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Lose Memories";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.LoseMemories;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Lose Memories reduces your experience
            if (!saveGame.Player.HasHoldLife && saveGame.Player.ExperiencePoints > 0)
            {
                saveGame.MsgPrint("You feel your memories fade.");
                saveGame.Player.LoseExperience(saveGame.Player.ExperiencePoints / 4);
                return true;
            }
            return false;
        }
        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            return true;
        }
    }
}
