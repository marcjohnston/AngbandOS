using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionRestoreMana : PotionItemCategory
    {
        public override char Character => '!';
        public override Colour Colour => Colour.Background;
        public override string Name => "Potion:Restore Mana";

        public override int Chance1 => 1;
        public override int Cost => 350;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Restore Mana";
        public override int Level => 25;
        public override int Locale1 => 25;
        public override int SubCategory => 40;
        public override int Weight => 4;
    }
}
