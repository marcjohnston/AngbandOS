using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffStarlight : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Staff:Starlight";

        public override int Chance1 => 1;
        public override int Cost => 800;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Starlight";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 7;
        public override int Weight => 50;
    }
}
