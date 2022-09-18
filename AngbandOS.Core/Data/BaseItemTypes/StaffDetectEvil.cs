using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffDetectEvil : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Staff:Detect Evil";

        public override int Chance1 => 1;
        public override int Cost => 350;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Detect Evil";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 15;
        public override int Weight => 50;
    }
}
