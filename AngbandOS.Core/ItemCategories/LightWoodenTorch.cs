using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class LightWoodenTorch : LightSourceItemClass
    {
        private LightWoodenTorch(SaveGame saveGame) { } // This object is a singleton.

        public override char Character => '~';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Wooden Torch";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 2;
        public override int Dd => 1;
        public override int Ds => 1;
        public override bool EasyKnow => true;
        public override string FriendlyName => "& Wooden Torch~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 0, 0, 0 };
        public override int Pval => 4000;
        public override int? SubCategory => 0;
        public override int Weight => 30;
    }
}
