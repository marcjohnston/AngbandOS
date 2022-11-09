using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldAdamantite : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "adamantite";

        public override int Cost => 80;
        public override string FriendlyName => "adamantite";
        public override int Level => 1;
    }
}
