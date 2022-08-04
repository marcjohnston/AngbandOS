using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class Goldadamantite : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Gold:adamantite";

        public override int Cost => 80;
        public override string FriendlyName => "adamantite";
        public override int Level => 1;
        public override int SubCategory => 18;
    }
}
