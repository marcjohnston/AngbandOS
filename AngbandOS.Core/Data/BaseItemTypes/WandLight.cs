using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandLight : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Light";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Light";
        public override int Level => 3;
        public override int Locale1 => 3;
        public override int? SubCategory => WandType.Light;
        public override int Weight => 10;
    }
}
