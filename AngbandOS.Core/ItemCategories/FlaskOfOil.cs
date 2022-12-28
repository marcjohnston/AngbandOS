using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class FlaskOfOil : FlaskItemClass
    {
        public FlaskOfOil(SaveGame saveGame) : base(saveGame) { }

        public override char Character => '!';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Flask of oil";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Flask~ of oil";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int Pval => 7500;
        public override int? SubCategory => 0;
        public override int Weight => 10;
    }
}
