using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class CloakElven : CloakItemCategory
    {
        public override char Character => '(';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Cloak:Elven Cloak";

        public override int Ac => 4;
        public override int Chance1 => 4;
        public override int Cost => 1500;
        public override string FriendlyName => "& Elven Cloak~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 30;
        public override int Locale1 => 30;
        public override bool Search => true;
        public override bool Stealth => true;
        public override int SubCategory => 2;
        public override int ToA => 4;
        public override int Weight => 5;
    }
}
