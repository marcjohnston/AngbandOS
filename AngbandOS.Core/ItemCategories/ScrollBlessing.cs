namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollBlessing : ScrollItemClass
    {
        private ScrollBlessing(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Blessing";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 15;
        public override string FriendlyName => "Blessing";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int? SubCategory => 33;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.Player.TimedBlessing.AddTimer(Program.Rng.DieRoll(12) + 6))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
