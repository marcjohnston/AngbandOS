using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class RodPolymorph : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Polymorph";

        public override int Chance1 => 1;
        public override int Cost => 1200;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Polymorph";
        public override int Level => 35;
        public override int Locale1 => 35;
        public override int SubCategory => 19;
        public override int Weight => 15;
    }
}
