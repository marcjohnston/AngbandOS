using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldGold1 : GoldItemClass
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Gold;
        public override string Name => "gold*";

        public override int Cost => 14;
        public override string FriendlyName => "gold";
        public override int Level => 1;
    }
}