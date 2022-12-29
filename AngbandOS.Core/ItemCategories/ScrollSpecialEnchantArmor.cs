using AngbandOS.Core.EventArgs;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollSpecialEnchantArmor : ScrollItemClass
    {
        private ScrollSpecialEnchantArmor(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "*Enchant Armor*";

        public override int[] Chance => new int[] { 1, 1, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "*Enchant Armor*";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 50, 0, 0 };
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
