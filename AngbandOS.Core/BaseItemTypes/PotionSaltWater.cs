using AngbandOS.Enumerations;
using AngbandOS.StaticData;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSaltWater : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Salt Water";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Salt Water";
        public override int? SubCategory => (int)PotionType.SaltWater;
        public override int Weight => 4;

        public override bool Quaff(SaveGame saveGame)
        {
            // Salt water makes you vomit, but gets rid of poison
            saveGame.MsgPrint("The saltiness makes you vomit!");
            saveGame.Player.SetFood(Constants.PyFoodStarve - 1);
            saveGame.Player.SetTimedPoison(0);
            saveGame.Player.SetTimedParalysis(saveGame.Player.TimedParalysis + 4);
            return true;
        }
    }
}
