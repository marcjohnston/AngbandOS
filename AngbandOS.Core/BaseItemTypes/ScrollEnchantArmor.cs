using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollEnchantArmor : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Enchant Armor";

        public override int Chance1 => 1;
        public override int Cost => 125;
        public override string FriendlyName => "Enchant Armor";
        public override int Level => 15;
        public override int Locale1 => 15;
        public override int? SubCategory => 16;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.Identified = true;
            if (!eventArgs.SaveGame.EnchantSpell(0, 0, 1))
            {
                eventArgs.UsedUp = false;
            }
        }
    }
}
