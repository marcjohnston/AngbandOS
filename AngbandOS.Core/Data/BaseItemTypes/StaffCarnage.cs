using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffCarnage : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Staff:Carnage";

        public override int Chance1 => 4;
        public override int Cost => 3500;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Carnage";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override int SubCategory => 27;
        public override int Weight => 50;
    }
}
