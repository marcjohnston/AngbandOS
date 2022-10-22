using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffHasteMonsters : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Haste Monsters";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Haste Monsters";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int? SubCategory => 2;
        public override int Weight => 50;
    }
}
