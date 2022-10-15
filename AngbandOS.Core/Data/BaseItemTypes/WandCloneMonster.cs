using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandCloneMonster : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Clone Monster";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Clone Monster";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int Locale2 => 50;
        public override int? SubCategory => WandType.CloneMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.CloneMonster(dir);
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
        }
    }
}
