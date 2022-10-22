using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class HaftedFlail : HaftedItemCategory
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Black;
        public override string Name => "Flail";

        public override int Chance1 => 1;
        public override int Cost => 353;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Flail~";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override bool ShowMods => true;
        public override int? SubCategory => 13;
        public override int Weight => 150;
    }
}
