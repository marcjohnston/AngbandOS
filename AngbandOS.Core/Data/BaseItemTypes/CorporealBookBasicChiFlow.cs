using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class CorporealBookBasicChiFlow : CorporealBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "CorporealBook:[Basic Chi Flow]";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Basic Chi Flow]";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Weight => 30;
    }
}
