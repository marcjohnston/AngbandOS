using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandStinkingCloud : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Stinking Cloud";

        public override int Chance1 => 1;
        public override int Cost => 400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Stinking Cloud";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => WandType.StinkingCloud;
        public override int Weight => 10;
    }
}
