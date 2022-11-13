using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionConstitution : PotionItemClass
    {
        public override char Character => '!';
        public override string Name => "Constitution";

        public override int[] Chance => new int[] { 6, 3, 1, 0 };
        public override int Cost => 8000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Constitution";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 25, 30, 0 };
        public override int? SubCategory => (int)PotionType.IncCon;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Constitution increases your constitution
            return saveGame.Player.TryIncreasingAbilityScore(Ability.Constitution);
        }
    }
}
