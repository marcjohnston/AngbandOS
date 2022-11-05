using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class PotionRestoreDexterity : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Restore Dexterity";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Dexterity";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.ResDex;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Restore wisdom restores your wisdom
            return saveGame.Player.TryRestoringAbilityScore(Ability.Wisdom);
        }
    }
}
