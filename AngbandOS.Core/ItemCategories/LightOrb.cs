using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LightOrb : LightSourceItemClass
    {
        public LightOrb(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '~';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "Orb";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Orb~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int Weight => 50;

        public override bool HasQuality => true;
    }
}
