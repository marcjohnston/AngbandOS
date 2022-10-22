using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class StaffDetectInvisible : StaffItemCategory
    {
        public override char Character => '_';
        public override string Name => "Detect Invisible";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "Detect Invisible";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => 14;
        public override int Weight => 50;
    }
}
