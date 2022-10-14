using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandSleepMonster : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Sleep Monster";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Sleep Monster";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int? SubCategory => 8;
        public override int Weight => 10;
    }
}
