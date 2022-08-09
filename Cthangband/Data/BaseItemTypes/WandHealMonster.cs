using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class WandHealMonster : WandItemCategory
    {
        public override char Character => '-';
        public override string Name => "Wand:Heal Monster";

        public override int Chance1 => 1;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Heal Monster";
        public override int Level => 2;
        public override int Locale1 => 2;
        public override int Weight => 10;
    }
}
