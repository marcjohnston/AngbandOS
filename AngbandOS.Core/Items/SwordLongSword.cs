using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SwordLongSword : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Long Sword";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 300;
        public override int Dd => 2;
        public override int Ds => 5;
        public override string FriendlyName => "& Long Sword~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 20, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 17;
        public override int Weight => 130;
    }
}