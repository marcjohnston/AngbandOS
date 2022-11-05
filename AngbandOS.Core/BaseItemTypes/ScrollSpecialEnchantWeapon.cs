using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollSpecialEnchantWeapon : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "*Enchant Weapon*";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "*Enchant Weapon*";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => 21;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (!eventArgs.SaveGame.EnchantSpell(Program.Rng.DieRoll(3), Program.Rng.DieRoll(3), 0))
            {
                eventArgs.UsedUp = false;
            }
            eventArgs.Identified = true;
        }
    }
}
