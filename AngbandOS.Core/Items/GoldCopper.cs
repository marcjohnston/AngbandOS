using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldCopper : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Copper;
        public override string Name => "copper";

        public override int Cost => 3;
        public override string FriendlyName => "copper";
        public override int Level => 1;
    }
}