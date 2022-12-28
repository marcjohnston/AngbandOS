using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmBeakedAxe : PolearmItemClass
    {
        private PolearmBeakedAxe(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Beaked Axe";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 408;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Beaked Axe~";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 10;
        public override int Weight => 180;
    }
}
