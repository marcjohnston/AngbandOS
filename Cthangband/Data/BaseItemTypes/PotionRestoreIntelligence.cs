using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionRestoreIntelligence : PotionItemCategory
    {
        public override char Character => '!';
        public override string Name => "Potion:Restore Intelligence";

        public override int Chance1 => 1;
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Intelligence";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int SubCategory => 43;
        public override int Weight => 4;
    }
}
