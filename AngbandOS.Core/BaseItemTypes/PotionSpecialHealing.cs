using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionSpecialHealing : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "*Healing*";

        public override int Chance1 => 4;
        public override int Chance2 => 2;
        public override int Chance3 => 1;
        public override int Cost => 1500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "*Healing*";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int Locale2 => 60;
        public override int Locale3 => 80;
        public override int? SubCategory => (int)PotionType.StarHealing;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;

            // *Healing* heals you 1200 health, and cures blindness, confusion, stun, poison,
            // and bleeding
            if (saveGame.Player.RestoreHealth(1200))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedBlindness(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedConfusion(0))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedPoison(0))
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

            return identified;
        }
    }
}
