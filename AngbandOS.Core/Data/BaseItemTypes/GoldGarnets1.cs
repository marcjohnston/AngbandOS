using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class GoldGarnets1 : GoldItemCategory
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Red;
        public override string Name => "Gold:garnets*";

        public override int Cost => 10;
        public override string FriendlyName => "garnets";
        public override int Level => 1;
        public override int? SubCategory => 8;
    }
}
