using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandStonetoMud : WandItemClass
    {
        public override char Character => '-';
        public override string Name => "Stone to Mud";

        public override int[] Chance => new int[] { 1, 1, 1, 0 };
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Stone to Mud";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 40, 80, 0 };
        public override int? SubCategory => WandType.StoneToMud;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.WallToMud(dir);
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(8) + 3;
        }
    }
}
