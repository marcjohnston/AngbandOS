using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class StaffCarnage : StaffItemClass
    {
        public override char Character => '_';
        public override string Name => "Carnage";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 3500;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Carnage";
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override int? SubCategory => 27;
        public override int Weight => 50;
    }
}