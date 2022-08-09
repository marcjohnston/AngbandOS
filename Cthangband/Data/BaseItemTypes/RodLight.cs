using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodLight : RodItemCategory
    {
        public override char Character => '-';
        public override string Name => "Rod:Light";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Light";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int SubCategory => 15;
        public override int Weight => 15;
    }
}
