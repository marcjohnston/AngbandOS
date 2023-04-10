namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandScareMonster : WandItemClass
    {
        private WandScareMonster(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Scare Monster";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Scare Monster";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => WandType.FearMonster;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.FearMonster(dir, 10);
        }
        public override Item CreateItem() => new ScareMonsterWandItem(SaveGame);
    }
}
