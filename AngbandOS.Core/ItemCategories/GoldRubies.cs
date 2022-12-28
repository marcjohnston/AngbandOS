using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldRubies : GoldItemClass
    {
        public GoldRubies(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '$';
        public override Colour Colour => Colour.Red;
        public override string Name => "rubies";

        public override int Cost => 24;
        public override string FriendlyName => "rubies";
        public override int Level => 1;
    }
}
