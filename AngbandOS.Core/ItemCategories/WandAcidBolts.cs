using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;
using System.Collections.Generic;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandAcidBolts : WandItemClass
    {
        public override char Character => '-';
        public override string Name => "Acid Bolts";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 950;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Acid Bolts";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => WandType.AcidBolt;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBoltOrBeam(20, new ProjectAcid(saveGame), dir, Program.Rng.DiceRoll(3, 8));
            return true;
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        }
    }
}
