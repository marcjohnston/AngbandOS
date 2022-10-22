using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionCureLightWounds : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Cure Light Wounds";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 15;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Cure Light Wounds";
        public override int Locale2 => 1;
        public override int Locale3 => 3;
        public override int Pval => 50;
        public override int? SubCategory => (int)PotionType.CureLight;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;
            // Cure light wounds heals you 2d8 health and reduces bleeding
            if (saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(2, 8)))
            {
                identified = true;
            }
            if (saveGame.Player.SetTimedBleeding(saveGame.Player.TimedBleeding - 10))
            {
                identified = true;
            }
            return identified;
        }
    }
}
