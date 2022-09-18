using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffSlowMonsters : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Staff:Slow Monsters";

        public override int Chance1 => 1;
        public override int Cost => 800;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Slow Monsters";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int SubCategory => 21;
        public override int Weight => 50;
    }
}
