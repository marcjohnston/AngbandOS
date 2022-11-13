using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionBoldness : PotionItemClass
    {
        public override char Character => '!';
        public override string Name => "Boldness";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 10;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Boldness";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.Boldness;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Boldness stops you being afraid
            return saveGame.Player.SetTimedFear(0);
        }
    }
}
