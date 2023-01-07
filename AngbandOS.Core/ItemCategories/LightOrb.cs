namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LightOrb : LightSourceItemClass
    {
        private LightOrb(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override bool IdentityCanBeSensed => true;
        public override char Character => '~';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "Orb";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;

        /// <summary>
        /// Returns an intensity of light provided by the orb.  A value of 2 is returned, plus an additional 3
        /// if the orb is an artifact.
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        public override int CalcTorch(Item oPtr)
        {
            return base.CalcTorch(oPtr) + 2;
        }
        public override int Ds => 1;
        public override string FriendlyName => "& Orb~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int Weight => 50;

        public override bool HasQuality => true;
    }
}
