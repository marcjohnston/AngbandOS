using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodPerception : RodItemCategory
    {
        public override char Character => '-';
        public override Colour Colour => Colour.Background;
        public override string Name => "Rod:Perception";

        public override int Chance1 => 8;
        public override int Chance2 => 8;
        public override int Cost => 13000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Perception";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Locale2 => 100;
        public override int SubCategory => 2;
        public override int Weight => 15;
    }
}
