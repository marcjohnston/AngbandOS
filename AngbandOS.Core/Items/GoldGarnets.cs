using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldGarnets : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Red;
        public override string Name => "garnets";

        public override int Cost => 9;
        public override string FriendlyName => "garnets";
        public override int Level => 1;
    }
}