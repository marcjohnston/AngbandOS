using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollEnchantWeaponToHit : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Enchant Weapon To-Hit";

        public override int Chance1 => 1;
        public override int Cost => 125;
        public override string FriendlyName => "Enchant Weapon To-Hit";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int? SubCategory => 17;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (!eventArgs.SaveGame.EnchantSpell(1, 0, 0))
            {
                eventArgs.UsedUp = false;
            }
            eventArgs.Identified = true;
        }
    }
}
