using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class Arrow : ArrowItemCategory
    {
        public override char Character => '{';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Arrow:Arrow";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 1;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "& Arrow~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int Locale2 => 15;
        public override bool ShowMods => true;
        public override int SubCategory => 1;
        public override int Weight => 2;
    }
}
