using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PolearmBeakedAxe : PolearmItemCategory
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Polearm:Beaked Axe";

        public override int Chance1 => 1;
        public override int Cost => 408;
        public override int Dd => 2;
        public override int Ds => 6;
        public override string FriendlyName => "& Beaked Axe~";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override bool ShowMods => true;
        public override int SubCategory => 10;
        public override int Weight => 180;
    }
}
