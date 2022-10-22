using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class SorceryBookBeginnersHandbook : SorceryBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "[Beginner's Handbook]";

        public override int Chance1 => 1;
        public override int Cost => 100;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Beginner's Handbook]";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int? SubCategory => 0;
        public override int Weight => 30;
    }
}
