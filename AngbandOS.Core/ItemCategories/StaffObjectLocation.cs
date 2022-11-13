using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffObjectLocation : StaffItemClass
    {
        public override char Character => '_';
        public override string Name => "Object Location";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Object Location";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 11;
        public override int Weight => 50;
    }
}
