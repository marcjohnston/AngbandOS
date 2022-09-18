using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SwordBroadSword : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sword:Broad Sword";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 255;
        public override int Dd => 2;
        public override int Ds => 5;
        public override string FriendlyName => "& Broad Sword~";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Locale2 => 15;
        public override bool ShowMods => true;
        public override int SubCategory => 16;
        public override int Weight => 150;
    }
}
