using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollSpecialEnchantArmor : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "*Enchant Armor*";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 500;
        public override string FriendlyName => "*Enchant Armor*";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Locale2 => 50;
        public override int? SubCategory => 20;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (!eventArgs.SaveGame.EnchantSpell(0, 0, Program.Rng.DieRoll(3) + 2))
            {
                eventArgs.UsedUp = false;
            }
            eventArgs.Identified = true;
        }
    }
}
