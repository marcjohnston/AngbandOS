using AngbandOS.Core.Interface;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollEnchantWeapon : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:*Enchant Weapon*";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override string FriendlyName => "*Enchant Weapon*";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int SubCategory => 21;
        public override int Weight => 5;
    }
}
