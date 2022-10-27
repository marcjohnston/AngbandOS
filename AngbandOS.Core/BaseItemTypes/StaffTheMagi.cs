using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffTheMagi : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "the Magi";

        public override int Chance1 => 2;
        public override int Cost => 4500;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "the Magi";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override int? SubCategory => 19;
        public override int Weight => 50;
    }
}
