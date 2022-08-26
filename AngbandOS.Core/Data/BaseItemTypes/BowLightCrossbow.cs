using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class BowLightCrossbow : BowItemCategory
    {
        public override char Character => '}';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Bow:Light Crossbow";

        public override int Chance1 => 1;
        public override int Cost => 140;
        public override string FriendlyName => "& Light Crossbow~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override bool ShowMods => true;
        public override int SubCategory => 23;
        public override int Weight => 110;
    }
}
