using AngbandOS.Core.Interface;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class GoldEmeralds : GoldItemClass
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Green;
        public override string Name => "emeralds";

        public override int Cost => 32;
        public override string FriendlyName => "emeralds";
        public override int Level => 1;
    }
}