using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ChestRuined : ChestItemCategory
    {
        public override char Character => '~';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Chest:Ruined chest";

        public override int Chance1 => 1;
        public override string FriendlyName => "& Ruined chest~";
        public override int Locale1 => 75;
        public override int Weight => 250;
    }
}
