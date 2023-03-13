namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ProtectionRingItem : RingItem
    {
        public ProtectionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingProtection>()) { }
    }
}