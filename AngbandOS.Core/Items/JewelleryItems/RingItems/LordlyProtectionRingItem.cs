namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LordlyProtectionRingItem : RingItem
    {
        public LordlyProtectionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingLordlyProtection>()) { }
        public override bool FreeAct => true;
        public override bool HoldLife => true;
        public override bool ResDisen => true;
        public override bool ResPois => true;
    }
}