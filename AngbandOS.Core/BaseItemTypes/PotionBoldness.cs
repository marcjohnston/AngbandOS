using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionBoldness : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Boldness";

        public override int Chance1 => 1;
        public override int Cost => 10;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Boldness";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int? SubCategory => (int)PotionType.Boldness;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Boldness stops you being afraid
            return saveGame.Player.SetTimedFear(0);
        }
    }
}
