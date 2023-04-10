namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class WandAnnihilation : WandItemClass
    {
        private WandAnnihilation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Annihilation";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 3000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Annihilation";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 0, 0, 0 };
        public override int? SubCategory => WandType.Annihilation;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.DrainLife(dir, 125);
        }
        public override Item CreateItem(SaveGame saveGame) => new AnnihilationWandItem(saveGame);
    }
}
