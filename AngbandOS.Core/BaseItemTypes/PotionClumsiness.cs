using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionClumsiness : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Clumsiness";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Clumsiness";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => (int)PotionType.DecDex;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Clumsiness tries to reduce your dexterity
            return saveGame.Player.TryDecreasingAbilityScore(Ability.Dexterity);
        }
    }
}
