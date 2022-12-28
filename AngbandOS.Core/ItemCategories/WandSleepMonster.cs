using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandSleepMonster : WandItemClass
    {
        public WandSleepMonster(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '-';
        public override string Name => "Sleep Monster";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Sleep Monster";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => WandType.SleepMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.SleepMonster(dir);
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
        }
    }
}
