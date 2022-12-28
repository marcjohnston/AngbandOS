using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmAwlPike : PolearmItemClass
    {
        private PolearmAwlPike(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Awl-Pike";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 340;
        public override int Dd => 1;
        public override int Ds => 8;
        public override string FriendlyName => "& Awl-Pike~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 4;
        public override int Weight => 160;
    }
}
