using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SwordKatana : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sword:Katana";

        public override int Chance1 => 1;
        public override int Cost => 400;
        public override int Dd => 3;
        public override int Ds => 4;
        public override string FriendlyName => "& Katana~";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override bool ShowMods => true;
        public override int? SubCategory => 20;
        public override int Weight => 120;
    }
}
