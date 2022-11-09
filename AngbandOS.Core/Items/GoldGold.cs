using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldGold : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Gold;
        public override string Name => "gold";

        public override int Cost => 12;
        public override string FriendlyName => "gold";
        public override int Level => 1;
    }
}
