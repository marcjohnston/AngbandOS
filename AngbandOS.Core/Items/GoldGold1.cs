using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldGold1 : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Gold;
        public override string Name => "gold*";

        public override int Cost => 14;
        public override string FriendlyName => "gold";
        public override int Level => 1;
    }
}