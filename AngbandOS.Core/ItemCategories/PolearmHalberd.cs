using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmHalberd : PolearmItemClass
    {
        public PolearmHalberd(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Halberd";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 430;
        public override int Dd => 3;
        public override int Ds => 5;
        public override string FriendlyName => "& Halberd~";
        public override int Level => 25;
        public override int[] Locale => new int[] { 25, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 15;
        public override int Weight => 190;
    }
}
