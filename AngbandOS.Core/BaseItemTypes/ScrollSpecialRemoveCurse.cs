using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollSpecialRemoveCurse : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "*Remove Curse*";

        public override int Chance1 => 2;
        public override int Chance2 => 2;
        public override int Chance3 => 2;
        public override int Chance4 => 1;
        public override int Cost => 8000;
        public override string FriendlyName => "*Remove Curse*";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Locale2 => 75;
        public override int Locale3 => 85;
        public override int Locale4 => 95;
        public override int? SubCategory => 15;
        public override int Weight => 5;
    }
}
