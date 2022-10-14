using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandStonetoMud : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Stone to Mud";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Stone to Mud";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int Locale2 => 40;
        public override int Locale3 => 80;
        public override int? SubCategory => 6;
        public override int Weight => 10;
    }
}
