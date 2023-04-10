namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollTrapCreation : ScrollItemClass
    {
        private ScrollTrapCreation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Trap Creation";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override string FriendlyName => "Trap Creation";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (eventArgs.SaveGame.TrapCreation())
            {
                eventArgs.Identified = true;
            }
        }
        public override Item CreateItem() => new TrapCreationScrollItem(SaveGame);
    }
}
