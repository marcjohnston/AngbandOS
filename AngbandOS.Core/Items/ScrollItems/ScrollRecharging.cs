namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollRecharging : ScrollItemClass
    {
        private ScrollRecharging(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Recharging";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 200;
        public override string FriendlyName => "Recharging";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override int? SubCategory => 22;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            if (!eventArgs.SaveGame.Recharge(60))
            {
                eventArgs.UsedUp = false;
            }
            eventArgs.Identified = true;
        }
        public override Item CreateItem() => new RechargingScrollItem(SaveGame);
    }
}
