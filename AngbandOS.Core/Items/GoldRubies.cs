using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldRubies : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Red;
        public override string Name => "rubies";

        public override int Cost => 24;
        public override string FriendlyName => "rubies";
        public override int Level => 1;
    }
}