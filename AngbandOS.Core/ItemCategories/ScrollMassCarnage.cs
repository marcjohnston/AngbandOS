using AngbandOS.Core.EventArgs;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollMassCarnage : ScrollItemClass
    {
        private ScrollMassCarnage(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Mass Carnage";

        public override int[] Chance => new int[] { 4, 4, 0, 0 };
        public override int Cost => 1000;
        public override string FriendlyName => "Mass Carnage";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 100, 0, 0 };
        public override int? SubCategory => 45;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.MassCarnage(true);
            eventArgs.Identified = true;
        }
    }
}
