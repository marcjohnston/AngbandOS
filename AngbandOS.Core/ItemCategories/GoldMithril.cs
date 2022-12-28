using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldMithril : GoldItemClass
    {
        public GoldMithril(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '$';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "mithril";

        public override int Cost => 40;
        public override string FriendlyName => "mithril";
        public override int Level => 1;
    }
}
