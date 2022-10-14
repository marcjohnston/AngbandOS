using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SoftArmorFilthyRag : SoftArmorItemCategory
    {
        public override char Character => '(';
        public override Colour Colour => Colour.Black;
        public override string Name => "SoftArmor:Filthy Rag";

        public override int Ac => 1;
        public override int Chance1 => 1;
        public override int Cost => 1;
        public override string FriendlyName => "& Filthy Rag~";
        public override int? SubCategory => 1;
        public override int ToA => -1;
        public override int Weight => 20;
    }
}
