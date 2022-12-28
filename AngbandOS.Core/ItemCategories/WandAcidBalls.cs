using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;
using AngbandOS.Projection;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandAcidBalls : WandItemClass
    {
        public WandAcidBalls(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '-';
        public override string Name => "Acid Balls";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1650;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Acid Balls";
        public override bool IgnoreAcid => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => WandType.AcidBall;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBall(new ProjectAcid(saveGame), dir, 60, 2);
            return true;
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(5) + 2;
        }
    }
}
