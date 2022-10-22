using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSpeed : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Speed";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 75;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Speed";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int Locale2 => 40;
        public override int Locale3 => 60;
        public override int? SubCategory => (int)PotionType.Speed;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Speed temporarily hastes you
            if (saveGame.Player.TimedHaste == 0)
            {
                if (saveGame.Player.SetTimedHaste(Program.Rng.DieRoll(25) + 15))
                {
                    return true;
                }
            }
            else
            {
                saveGame.Player.SetTimedHaste(saveGame.Player.TimedHaste + 5);
            }
            return false;
        }
    }
}
