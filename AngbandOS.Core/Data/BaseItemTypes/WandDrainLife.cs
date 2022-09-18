using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandDrainLife : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Drain Life";

        public override int Chance1 => 1;
        public override int Cost => 1200;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Drain Life";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int SubCategory => 12;
        public override int Weight => 10;
    }
}
