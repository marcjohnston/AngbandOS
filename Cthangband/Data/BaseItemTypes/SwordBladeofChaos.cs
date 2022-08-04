using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SwordBladeofChaos : SwordItemCategory
    {
        public override char Character => '|';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Sword:Blade of Chaos";

        public override int Chance1 => 8;
        public override int Cost => 4000;
        public override int Dd => 6;
        public override int Ds => 5;
        public override string FriendlyName => "& Blade~ of Chaos";
        public override int Level => 70;
        public override int Locale1 => 70;
        public override bool ResChaos => true;
        public override bool ShowMods => true;
        public override int SubCategory => 30;
        public override int Weight => 180;
    }
}
