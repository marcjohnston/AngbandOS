using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GlovesSetOfLeatherGloves : GlovesItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Gloves:Set of Leather Gloves";

        public override int Ac => 1;
        public override int Chance1 => 1;
        public override int Cost => 3;
        public override string FriendlyName => "& Set~ of Leather Gloves";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int? SubCategory => 1;
        public override int Weight => 5;
    }
}
