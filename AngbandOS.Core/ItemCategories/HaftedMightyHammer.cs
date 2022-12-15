using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HaftedMightyHammer : HaftedItemClass
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Mighty Hammer";

        public override int Cost => 1000;
        public override int Dd => 3;
        public override int Ds => 9;
        public override string FriendlyName => "& Mighty Hammer~"; // TODO: This appears to cause a defect in identification
        public override bool InstaArt => true;
        public override int Level => 15;
        public override bool ShowMods => true;
        public override int? SubCategory => 50;
        public override int Weight => 200;
    }
}
