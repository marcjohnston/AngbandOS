using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldAdamantite : GoldItemClass
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "adamantite";

        public override int Cost => 80;
        public override string FriendlyName => "adamantite";
        public override int Level => 1;
    }
}