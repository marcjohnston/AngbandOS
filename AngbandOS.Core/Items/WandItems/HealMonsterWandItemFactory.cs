namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HealMonsterWandItemFactory : WandItemFactory
    {
        private HealMonsterWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

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
        public override Item CreateItem() => new HealMonsterWandItem(SaveGame);
    }
}