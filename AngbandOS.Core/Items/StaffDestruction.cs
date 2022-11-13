using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffDestruction : StaffItemClass
    {
        public override char Character => '_';
        public override string Name => "*Destruction*";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 2500;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "*Destruction*";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 70, 0, 0 };
        public override int? SubCategory => 29;
        public override int Weight => 50;
    }
}
