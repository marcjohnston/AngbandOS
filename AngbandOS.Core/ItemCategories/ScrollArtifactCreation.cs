namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollArtifactCreation : ScrollItemClass
    {
        private ScrollArtifactCreation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Artifact Creation";

        public override int[] Chance => new int[] { 16, 0, 0, 0 };
        public override int Cost => 200000;
        public override string FriendlyName => "Artifact Creation";
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override int? SubCategory => 52;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.ArtifactScroll();
            eventArgs.Identified = true;
        }
    }
}
