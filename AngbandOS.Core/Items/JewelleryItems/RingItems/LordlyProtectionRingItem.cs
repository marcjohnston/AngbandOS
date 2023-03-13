namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LordlyProtectionRingItem : RingItem
    {
        public LordlyProtectionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingLordlyProtection>()) { }
    }
}