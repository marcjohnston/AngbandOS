using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SwordSabre : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sword:Sabre";

        public override int Chance1 => 1;
        public override int Cost => 50;
        public override int Dd => 1;
        public override int Ds => 7;
        public override string FriendlyName => "& Sabre~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override bool ShowMods => true;
        public override int? SubCategory => 11;
        public override int Weight => 50;
    }
}
