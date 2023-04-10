namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandMagicMissile : WandItemClass
    {
        private WandMagicMissile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Magic Missile";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Magic Missile";
        public override int Level => 2;
        public override int[] Locale => new int[] { 2, 0, 0, 0 };
        public override int? SubCategory => WandType.MagicMissile;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBoltOrBeam(20, new MissileProjectile(saveGame), dir, Program.Rng.DiceRoll(2, 6));
            return true;
        }
        public override Item CreateItem() => new MagicMissileWandItem(SaveGame);
    }
}
