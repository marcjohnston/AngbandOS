using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class FolkBookCantripsforBeginners : FolkBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "[Cantrips for Beginners]";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Cantrips for Beginners]";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 0;
        public override int Weight => 30;
        public override bool KindIsGood => false;
    }
}
