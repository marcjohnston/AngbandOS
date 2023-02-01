namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollLight : ScrollItemClass
    {
        private ScrollLight(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Light";

        public override int[] Chance => new int[] { 1, 1, 1, 0 };
        public override int Cost => 15;
        public override string FriendlyName => "Light";
        public override int[] Locale => new int[] { 0, 3, 10, 0 };
        public override int? SubCategory => 24;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.LightArea(Program.Rng.DiceRoll(2, 8), 2))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
