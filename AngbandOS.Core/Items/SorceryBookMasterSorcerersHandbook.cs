using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SorceryBookMasterSorcerersHandbook : SorceryBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "[Master Sorcerer's Handbook]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Master Sorcerer's Handbook]";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 1;
        public override int Weight => 30;
        public override bool KindIsGood => false;
    }
}
