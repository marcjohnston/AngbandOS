using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmScythe : PolearmItemClass
    {
        private PolearmScythe(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Scythe";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 800;
        public override int Dd => 5;
        public override int Ds => 3;
        public override string FriendlyName => "& Scythe~";
        public override int Level => 45;
        public override int[] Locale => new int[] { 45, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 17;
        public override int Weight => 250;
    }
}
