using AngbandOS.Interface;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PolearmPike : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Polearm:Pike";

        public override int Chance1 => 1;
        public override int Cost => 358;
        public override int Dd => 2;
        public override int Ds => 5;
        public override string FriendlyName => "& Pike~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override bool ShowMods => true;
        public override int SubCategory => 8;
        public override int Weight => 160;
    }
}
