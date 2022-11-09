using AngbandOS.Enumerations;
using System;
using System.Collections.Generic;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandHealMonster : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Heal Monster";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Heal Monster";
        public override int Level => 2;
        public override int[] Locale => new int[] { 2, 0, 0, 0 };
        public override int? SubCategory => WandType.HealMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.HealMonster(dir);
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
        }
    }
}
