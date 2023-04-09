namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandDragonsBreath : WandItemClass
    {
        private WandDragonsBreath(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Dragon's Breath";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 2400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Dragon's Breath";
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 0, 0, 0 };
        public override int? SubCategory => WandType.DragonBreath;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            switch (Program.Rng.RandomLessThan(5))
            {
                case 0:
                    saveGame.FireBall(new AcidProjectile(saveGame), dir, 100, -3);
                    break;
                case 1:
                    saveGame.FireBall(new ElecProjectile(saveGame), dir, 80, -3);
                    break;
                case 2:
                    saveGame.FireBall(new FireProjectile(saveGame), dir, 100, -3);
                    break;
                case 3:
                    saveGame.FireBall(new ColdProjectile(saveGame), dir, 80, -3);
                    break;
                case 4:
                    saveGame.FireBall(new PoisProjectile(saveGame), dir, 60, -3);
                    break;
                default:
                    throw new Exception("Internal error.");
            }
            return true;
        }
        public override void ApplyMagic(Item item, int level, int power)
        {
            item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        }
        public override Item CreateItem(SaveGame saveGame) => new DragonsBreathWandItem(saveGame);
    }
}
