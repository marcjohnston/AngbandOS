using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandDisarming : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Disarming";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 700;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Disarming";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => WandType.Disarming;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.DisarmTrap(dir);
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(5) + 4;
        }
    }
}