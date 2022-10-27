using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffDestruction : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "*Destruction*";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 2500;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "*Destruction*";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Locale2 => 70;
        public override int? SubCategory => 29;
        public override int Weight => 50;
    }
}
