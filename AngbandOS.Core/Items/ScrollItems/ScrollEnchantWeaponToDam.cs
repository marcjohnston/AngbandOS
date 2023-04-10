namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollEnchantWeaponToDam : ScrollItemClass
    {
        private ScrollEnchantWeaponToDam(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

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
            if (!eventArgs.SaveGame.EnchantItem(0, 1, 0))
            {
                eventArgs.UsedUp = false;
            }
            eventArgs.Identified = true;
        }
        public override Item CreateItem() => new EnchantWeaponToDamScrollItem(SaveGame);
    }
}
