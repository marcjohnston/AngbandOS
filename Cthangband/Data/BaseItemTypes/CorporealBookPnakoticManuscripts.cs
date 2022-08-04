using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class CorporealBookPnakoticManuscripts : CorporealBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "CorporealBook:[Pnakotic Manuscripts]";

        public override int Chance1 => 3;
        public override int Cost => 100000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Pnakotic Manuscripts]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 90;
        public override int Locale1 => 90;
        public override int SubCategory => 3;
        public override int Weight => 30;
    }
}
