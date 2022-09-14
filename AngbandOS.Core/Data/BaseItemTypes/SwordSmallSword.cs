using AngbandOS.Core.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SwordSmallSword : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Sword:Small Sword";

        public override int Chance1 => 1;
        public override int Cost => 48;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "& Small Sword~";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override bool ShowMods => true;
        public override int SubCategory => 8;
        public override int Weight => 75;
    }
}
