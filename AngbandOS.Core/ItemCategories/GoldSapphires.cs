using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldSapphires : GoldItemClass
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Blue;
        public override string Name => "sapphires";

        public override int Cost => 20;
        public override string FriendlyName => "sapphires";
        public override int Level => 1;
    }
}