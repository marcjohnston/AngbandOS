using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionRestoreLifeLevels : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Restore Life Levels";

        public override int Chance1 => 1;
        public override int Cost => 400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Life Levels";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int? SubCategory => (int)PotionType.RestoreExp;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Restore life levels restores any lost experience
            return saveGame.Player.RestoreLevel();
        }
    }
}
