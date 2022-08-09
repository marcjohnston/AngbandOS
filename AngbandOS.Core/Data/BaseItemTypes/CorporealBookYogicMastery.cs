using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class CorporealBookYogicMastery : CorporealBookItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "CorporealBook:[Yogic Mastery]";

        public override int Chance1 => 1;
        public override int Cost => 1000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Yogic Mastery]";
        public override int Level => 20;
        public override int Locale1 => 20;
        public override int SubCategory => 1;
        public override int Weight => 30;
    }
}
