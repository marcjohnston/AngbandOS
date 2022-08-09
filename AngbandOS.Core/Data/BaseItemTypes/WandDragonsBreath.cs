using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class WandDragonsBreath : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Dragon's Breath";

        public override int Chance1 => 4;
        public override int Cost => 2400;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Dragon's Breath";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 60;
        public override int Locale1 => 60;
        public override int SubCategory => 28;
        public override int Weight => 10;
    }
}
