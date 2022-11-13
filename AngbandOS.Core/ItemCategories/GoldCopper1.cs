using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldCopper1 : GoldItemClass
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Copper;
        public override string Name => "copper*";

        public override int Cost => 4;
        public override string FriendlyName => "copper";
        public override int Level => 1;
    }
}
