using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffEnlightenment : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Enlightenment";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 750;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Enlightenment";
        public override int Level => 20;
        public override int[] Locale => new int[] { 20, 0, 0, 0 };
        public override int? SubCategory => 9;
        public override int Weight => 50;
    }
}