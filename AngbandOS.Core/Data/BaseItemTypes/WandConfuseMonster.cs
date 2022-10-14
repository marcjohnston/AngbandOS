using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandConfuseMonster : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Confuse Monster";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Confuse Monster";
        public override int Level => 5;
        public override int Locale1 => 3;
        public override int? SubCategory => 10;
        public override int Weight => 10;
    }
}
