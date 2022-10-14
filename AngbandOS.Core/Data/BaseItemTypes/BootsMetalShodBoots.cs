using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class BootsMetalShodBoots : BootsItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Boots:Pair of Metal Shod Boots";

        public override int Ac => 6;
        public override int Chance1 => 1;
        public override int Cost => 50;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Pair~ of Metal Shod Boots";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int? SubCategory => 6;
        public override int Weight => 80;
    }
}
