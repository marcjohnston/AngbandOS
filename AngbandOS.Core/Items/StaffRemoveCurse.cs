using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffRemoveCurse : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Remove Curse";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Remove Curse";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 6;
        public override int Weight => 50;
    }
}