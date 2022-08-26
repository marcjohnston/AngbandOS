using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class HelmHardLeatherCap : HelmItemCategory
    {
        public override char Character => ']';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Helm:Hard Leather Cap";

        public override int Ac => 2;
        public override int Chance1 => 1;
        public override int Cost => 12;
        public override string FriendlyName => "& Hard Leather Cap~";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int SubCategory => 2;
        public override int Weight => 15;
    }
}
