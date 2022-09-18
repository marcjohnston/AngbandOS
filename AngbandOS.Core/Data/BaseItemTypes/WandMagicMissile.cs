using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class WandMagicMissile : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Magic Missile";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Magic Missile";
        public override int Level => 2;
        public override int Locale1 => 2;
        public override int SubCategory => 15;
        public override int Weight => 10;
    }
}
