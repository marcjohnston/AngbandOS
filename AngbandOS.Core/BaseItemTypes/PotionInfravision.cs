using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionInfravision : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Infra-vision";

        public override int Chance1 => 1;
        public override int Cost => 20;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Infra-vision";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int? SubCategory => (int)PotionType.Infravision;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Infravision gives you timed infravision
            return saveGame.Player.SetTimedInfravision(saveGame.Player.TimedInfravision + 100 + Program.Rng.DieRoll(100));
        }
    }
}
