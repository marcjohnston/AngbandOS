using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldCopper2 : GoldItemClass
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Copper;
        public override string Name => "copper**";

        public override int Cost => 5;
        public override string FriendlyName => "copper";
        public override int Level => 1;
    }
}