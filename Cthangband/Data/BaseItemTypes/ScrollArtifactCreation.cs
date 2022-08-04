using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollArtifactCreation : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Artifact Creation";

        public override int Chance1 => 16;
        public override int Cost => 200000;
        public override string FriendlyName => "Artifact Creation";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override int SubCategory => 52;
        public override int Weight => 5;
    }
}
