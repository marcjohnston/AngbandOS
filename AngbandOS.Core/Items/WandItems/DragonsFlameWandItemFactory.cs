namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DragonsFlameWandItemFactory : WandItemFactory
    {
        private DragonsFlameWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Dragon's Flame";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 2400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Dragon's Flame";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => WandType.DragonFire;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, 100, 3);
            return true;
        }
        public override Item CreateItem() => new DragonsFlameWandItem(SaveGame);
    }
}
