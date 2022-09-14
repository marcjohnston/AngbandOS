using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class CrownLead : CrownItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.Black;
        public override string Name => "Crown:Lead Crown";

        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "& Lead Crown~";
        public override bool InstaArt => true;
        public override int Level => 44;
        public override int SubCategory => 50;
        public override int Weight => 20;
    }
}
