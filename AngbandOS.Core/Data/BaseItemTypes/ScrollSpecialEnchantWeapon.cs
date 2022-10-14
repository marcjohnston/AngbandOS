using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollSpecialEnchantWeapon : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "*Enchant Weapon*";

        public override int Chance1 => 1;
        public override int Cost => 500;
        public override string FriendlyName => "*Enchant Weapon*";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int? SubCategory => 21;
        public override int Weight => 5;
    }
}
