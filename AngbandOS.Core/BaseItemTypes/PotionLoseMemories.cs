using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionLoseMemories : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Lose Memories";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Lose Memories";
        public override int Level => 10;
        public override int Locale1 => 10;
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
