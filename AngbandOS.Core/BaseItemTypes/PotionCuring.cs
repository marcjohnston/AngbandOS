using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionCuring : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Curing";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 250;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Curing";
        public override int Level => 18;
        public override int Locale1 => 18;
        public override int Locale2 => 40;
        public override int Pval => 100;
        public override int? SubCategory => (int)PotionType.Curing;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;
            // Curing heals you 50 health, and cures blindness, confusion, stun, poison,
            // bleeding, and hallucinations
            if (saveGame.Player.RestoreHealth(50))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedBlindness(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedPoison(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedConfusion(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedStun(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedBleeding(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedHallucinations(0))
            {
                identified = true;
            }
            return identified;
        }
    }
}
