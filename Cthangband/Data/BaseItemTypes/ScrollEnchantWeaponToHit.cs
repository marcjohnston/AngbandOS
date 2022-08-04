using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollEnchantWeaponToHit : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Enchant Weapon To-Hit";

        public override int Chance1 => 1;
        public override int Cost => 125;
        public override string FriendlyName => "Enchant Weapon To-Hit";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int SubCategory => 17;
        public override int Weight => 5;
    }
}
