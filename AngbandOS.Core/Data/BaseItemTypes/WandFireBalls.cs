using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandFireBalls : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Fire Balls";

        public override int Chance1 => 1;
        public override int Cost => 1800;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Fire Balls";
        public override bool IgnoreFire => true;
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int SubCategory => 22;
        public override int Weight => 10;
    }
}
