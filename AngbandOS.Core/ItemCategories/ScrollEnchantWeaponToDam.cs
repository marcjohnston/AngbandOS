using AngbandOS.Core.EventArgs;
using AngbandOS.Enumerations;
using System;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollEnchantWeaponToDam : ScrollItemClass
    {
        public override char Character => '?';
        public override string Name => "Enchant Weapon To-Dam";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 125;
        public override string FriendlyName => "Enchant Weapon To-Dam";
        public override int Level => 15;
        public override int[] Locale => new int[] { 15, 0, 0, 0 };
        public override int? SubCategory => 18;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (!eventArgs.SaveGame.EnchantSpell(0, 1, 0))
            {
                eventArgs.UsedUp = false;
            }
            eventArgs.Identified = true;
        }
    }
}