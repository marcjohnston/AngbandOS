using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class Cloak : CloakItemClass
    {
        public override char Character => '(';
        public override Colour Colour => Colour.Green;
        public override string Name => "Cloak";

        public override int Ac => 1;
        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 3;
        public override string FriendlyName => "& Cloak~";
        public override int Level => 1;
        public override int[] Locale => new int[] { 1, 20, 0, 0 };
        public override int? SubCategory => 1;
        public override int Weight => 10;
    }
}
