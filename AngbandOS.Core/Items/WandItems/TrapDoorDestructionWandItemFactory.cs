namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class TrapDoorDestructionWandItemFactory : WandItemFactory
    {
        private TrapDoorDestructionWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '-';
        public override string Name => "Trap/Door Destruction";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Trap/Door Destruction";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => WandType.TrapDoorDest;
        public override int Weight => 10;
        public override bool ExecuteActivation(SaveGame saveGame, int dir)
        {
            return saveGame.DestroyDoor(dir);
        }
        public override Item CreateItem() => new TrapDoorDestructionWandItem(SaveGame);
    }
}
